using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new HubConnection("http://localhost:59788/signalr"))
            {
                var proxy = connection.CreateHubProxy("ChatHub");
                proxy.On("ShowMessage", data =>
                {
                    Console.WriteLine(data);
                });

                connection.Start().Wait();

                proxy.Invoke("Send", new { UserName = "Test", Message = "Message" }).Wait();

                Console.WriteLine("No message should be shown at this moment");
                proxy.Invoke("Send", new { UserName = "Test", Message = "MessageToGroup" }, "group").Wait();

                Console.WriteLine("Join group and resend message");
                proxy.Invoke("JoinGroup", "group").Wait();
                proxy.Invoke("Send", new { UserName = "Test", Message = "MessageToGroup1" }, "group").Wait();

                Console.ReadLine();
            }

        }
    }
}
