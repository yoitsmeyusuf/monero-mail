using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
//using MoneroRPC;
//using MoneroRPC.NET;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MoneroMail
{
    class MailApp
    {
        //private string Password = "It will change";
        //private string username = "0x32132132132131";
        //string url = "http://localhost:18081/json_rpc";


     
        //private MoneroDaemonRpcClient daemon;
        //private MoneroMoney test;
        
        public Dictionary<string, string> Inbox { get; private set; }
        public Dictionary<string, string> Outbox { get; private set; }

        public MailApp()
        {
           
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            // HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Stream resStream = response.GetResponseStream();
            //Uri a = new Uri("http://localhost:18081/json_rpc");
            //daemon = new MoneroDaemonRpcClient(a);
            //Inbox = new Dictionary<string, string>();
            //Outbox = new Dictionary<string, string>();

        }

         async  public void SendMessage(string message,string senderadress)
        {
            string signature = "211";// I will change this
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:18082/json_rpc"))
                {
                    request.Content = new StringContent("{\"method\":\"sign\", \"params\":{\"data\":\""+ message + "\"}}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");//I will change this too

                    var response = await httpClient.SendAsync(request);
                    
                }
                //With this code you can sign message and it gets signature adress but I dont know how to get json as an variable
                //so I am trying to learn how can I do it
              
            }
            
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:18082/json_rpc"))
                {
                    request.Content = new StringContent("{\"method\":\"verify\",\"params\":{\"data\":\""+message+"\", \"address\":\""+senderadress+"\", \"signature\":\""+signature+"\"}}");
                   
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    //if this return true the
                }
            }
        }

        public void ReceiveMessage(string senderAddress, string subject, string encryptedMessage)
        {
            // Decrypt the message using the private view key
            //string privateViewKey = daemon.GetPrivateViewKey(senderAddress);
            //string message = daemon.DecryptMessage(encryptedMessage, privateViewKey);

            //// Add the message to the inbox
            //Inbox[subject] = message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the MailApp
            MailApp app = new MailApp();

            // Send a message
            app.SendMessage("Hello, how are you?","131231231");

            // Receive the message
            app.ReceiveMessage("sender_address", "Hello", app.Outbox["Hello"]);

            // Print the message
            Console.WriteLine(app.Inbox["Hello"]);
        }
    }
}
