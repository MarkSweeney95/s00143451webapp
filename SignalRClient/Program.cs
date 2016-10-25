using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClient
{
    class Program
    {
        static string name;
        static IHubProxy proxy;
     

        static void Main(string[] args)
        {
            /////////////////////setting up proxy/////////////////////
            HubConnection connection = new HubConnection("http://localhost:20805/");
            proxy = connection.CreateHubProxy("ChatHub");

            Action<string, string> SendMessageRecieved = recieved_a_message;
            proxy.On("broadcastMessage", SendMessageRecieved);
            connection.Start().Wait();
            Console.Write("Enter your Name: ");
            name = Console.ReadLine();
            proxy.Invoke("Send", new object[] { name, "Has Just Joined" });
            Console.ReadLine();

            connection.Start(); 

           
            /////////////////////setting up proxy/////////////////////

            Console.Write("Enter your Name: ");
            name = Console.ReadLine();
            proxy.Invoke("Send", new object[] { name, "Has Entered the game: " });

        }
        private static void Connection_Received(string obj)
        {
            Console.WriteLine("Message Recieved {0}", obj);
        }
        private static void recieved_a_message(string sender, string message)
        {
            Console.WriteLine("{0} : {1}", sender, message);
        }

    }
}
