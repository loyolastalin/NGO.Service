using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NGO.Service.IntegrationTestHarness
{
    /// <summary>
    /// Provides the facility to call the service
    /// </summary>
    internal static class RestServiceClient
    {
        public static string InputMessage { get; set; }

        public static async Task<T> GetFeeds<T>(string url, string inputMessage)
        {
            if (!string.IsNullOrEmpty(inputMessage))
            {
                url = url + "?" + inputMessage;
            }

            var responseResult = await new HttpClient().GetStringAsync(url);
            return Deserialize<T>(responseResult);
        }

        public static T CallRestService<T>(string url, string inputMessage, MethodType methodType)
        {
            InputMessage = inputMessage;
            T returnObject = default(T);
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = methodType.ToString();
            request.ContentType = "text/xml";

            if (!string.IsNullOrWhiteSpace(InputMessage))
            {
                AddRequest(request.GetRequestStream());
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            // For void calls.
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return default(T);
            }

            Stream result = response.GetResponseStream();

            returnObject = ConvertToObject<T>(result);

            return returnObject;
        }

        public static T Deserialize<T>(string data)
        {
            T list = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
            return list;
        }

        private static T ConvertToObject<T>(Stream stram)
        {
            T resObj = default(T);
            using (StreamReader reader = new StreamReader(stram))
            {
                string responseResult = reader.ReadToEnd();

                using (MemoryStream memoryStram = new MemoryStream(Encoding.Unicode.GetBytes(responseResult)))
                {
                    resObj = ConvertToObject<T>(memoryStram);
                }
            }

            return resObj;
        }

        private static T ConvertToObject<T>(MemoryStream memoryStram)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(memoryStram);
        }

        private static void AddRequest(Stream request)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(InputMessage);

            using (request)
            {
                request.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
