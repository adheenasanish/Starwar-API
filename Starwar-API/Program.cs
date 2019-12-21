using System;
using System.IO;
using System.Net;
using System.Text;

namespace Starwar_API
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "https://swapi.co/api/";
            string planets = "planets/";
            try
            {
                Uri uri = new Uri(baseUrl + planets);

                // Create a web request for the given uri
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                // Get the web response from the api
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Get a stream to read the reponse
                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                // Read the response and write it to the console
                Console.WriteLine(responseStream.ReadToEnd());
                // Close the connection to the api and the stream reader
                response.Close();
                responseStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured. Could not get planets:\n" + e.Message);
            }
            Console.ReadLine();

        }
    }
}
