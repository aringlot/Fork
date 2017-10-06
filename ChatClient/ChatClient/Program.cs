using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                var cookieContainer = new CookieContainer();
                cookieContainer.Add(new Cookie
                {
                    Domain = "localhost",
                    Name = ".MinSideApp",
                    Value = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjMzY2JlN2YwMGY2YmEwZTJmODg2MDYwNmU4NDMwNDJmIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1MDcyOTEzMTgsImV4cCI6MTUwNzI5NDkxOCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjpbImh0dHA6Ly9sb2NhbGhvc3Q6NTAwMC9yZXNvdXJjZXMiLCJhcGkiXSwiY2xpZW50X2lkIjoiYXBpIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTUwNzI5MTMxNywiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJhcGkiXSwiYW1yIjpbInB3ZCJdfQ.FVtXy8-UgeYzDH19dDeyUD-6QyWjONxNTa3EcH1W8aGT3uMRkEvzRtjI_v2hMC7QO5AX5SazH5_cKXuVI11LAvDFrKvzHb0QQDWG1Aj0wyn0wUxWum7JKUY6kWCZTD9HmMlnjJX5bmj3kHD3VZr0cY0OQLjI9r4PnU0XM_0TbflL2yoDG5ITQqbDMP1DhbwB7NEGPee6SdrwtVak49G2b3UMWrnujooFTAt5vJGHM3nQqIHTxnqjTnKG7xLjhnT-Cih132_VpxwZVbQu2F7Dfp9gBIjp42A9P2uZi5fhwLf7ziyIx3rAo3JyU02Vx9JOiKNLYMofae0spovLKMgOWg"
                });

                connection.CookieContainer = cookieContainer;

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
