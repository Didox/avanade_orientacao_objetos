using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HTTPRequest
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:3000/api/login?login=Danilod&senha=123456");
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            if (responseString.Contains("true"))
            {
                Console.WriteLine("Validado");
            }
            else
            {
                Console.WriteLine("Invalidado");
            }

        }
    }
}
