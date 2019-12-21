using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Starwar_API
{
    class Program
    {
        const string BASE_URL = "https://swapi.co/api/";
        static void Main(string[] args)
        {
            const string PLANETS = "planets/";
            // const string PEOPLE = "people/";
            JObject names = CallRestMethod(new Uri(BASE_URL + PLANETS));
            JArray resultsFrom = (JArray)names.SelectToken("results");

            foreach (JToken result in resultsFrom)
            {
                string planetName = (string)result.SelectToken("name");
                Console.WriteLine("Planet Name :  " + planetName);

            }
                // Console.WriteLine(CallRestMethod(new Uri(BASE_URL + PEOPLE)));
                Console.ReadLine();
        }

        static JObject CallRestMethod(Uri uri)
        {
            try
            {
                // Create a web request for the given uri
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                // Get the web response from the api
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Get a stream to read the reponse
                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                // Read the response and write it to the console
                JObject result = JObject.Parse(responseStream.ReadToEnd());
                // Close the connection to the api and the stream reader
                response.Close();
                responseStream.Close();
                return result;
            }
            catch (Exception e)
            {
                string result = $"{{'Error':'An error has occured. Could not get {uri.LocalPath}', 'Message': '{e.Message}'}}";
                return JObject.Parse(result);
            }
        }
    }

}
