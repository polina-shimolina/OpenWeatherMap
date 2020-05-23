using ConsoleApp8;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main()
        {

            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?id=2172797&units=metric&appid=ecc0ea77210f8032ef8804a80a9f40f0");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            Weather weather = JsonConvert.DeserializeObject<Weather>(responseFromServer);
            Console.WriteLine($" t in {weather.name}: {weather.main.temp} C");
            Console.ReadLine();
        }
    }
}