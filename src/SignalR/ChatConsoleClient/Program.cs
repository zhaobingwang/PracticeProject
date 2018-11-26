using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/ChatHub")
                .Build();
            connection.StartAsync();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            Console.WriteLine("input your nickname:");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                return;
            }
            Console.WriteLine("set success,start chat!");

            Console.ForegroundColor = ConsoleColor.Green;
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                if (user == userName)
                {
                    return;
                }
                var newMessage = $"{user}:{message}";
                Console.WriteLine(newMessage);
            });

            string line;
            while (true)
            {
                line = Console.ReadLine();
                connection.InvokeAsync("SendMessage", userName, line).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Console.WriteLine($"connection error!");
                    }
                });
            }
        }
    }
}
