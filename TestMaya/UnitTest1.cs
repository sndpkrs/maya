using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;

namespace TestMaya
{
    public class Tests
    {    

        [Test]
        public void TestIntent()
        {   
            //Get current directory and folder and list the sub directories
            DirectoryInfo d = new DirectoryInfo("./../../../RequestResponses/");
            DirectoryInfo[] diArr = d.GetDirectories();
            string requestBody = "";
            string responseBody = "";

            // Loop over all sub directories
            foreach (DirectoryInfo dir in diArr)
            {
                var client = new RestClient("http://localhost:61138/api/Alexa/question");
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Content-Length", "35204");
                request.AddHeader("Accept-Encoding", "gzip, deflate");
                request.AddHeader("Host", "localhost:61138");
                request.AddHeader("Postman-Token", "a80120e4-31e8-43a9-aaf0-9f1fcf86883f,f5eea8d3-dabd-4e0b-ba7d-7a2ba1566961");
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Accept", "*/*");
                request.AddHeader("User-Agent", "PostmanRuntime/7.19.0");
                request.AddHeader("Content-Type", "application/json");

                //Read json data from request file
                using (StreamReader r = new StreamReader(dir+"\\Request.json"))
                {  
                    requestBody = r.ReadToEnd();
                }

                //Add the file content to request body
                request.AddParameter("application / json", requestBody, ParameterType.RequestBody);

                //Create a request
                IRestResponse response = client.Execute(request);
                string message = JsonConvert.SerializeObject(response.Content);

                //Read pre-defined response
                using (StreamReader r = new StreamReader( dir + "\\Response.json"))
                {
                    responseBody = r.ReadToEnd();
                }

                string msg = JsonConvert.SerializeObject(responseBody);

                // Verify the content of response and the content of pre-defined response are equal then write result to a text file
                if (message.Equals(responseBody))
                {
                    File.AppendAllText("./../../../ResultLog.txt", "[" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "] " + dir.Name+" test PASSED\n");
                }
                else
                {
                    File.AppendAllText("./../../../ResultLog.txt", "["+DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"] "+dir.Name + " test FAILED\n");
                }
            }
        }
    }
}