using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace PingSimple;

class Program
{
    static void Main()
    {
        string url = "google.com";
        Ping pingSender = new();

        Console.WriteLine($"Pinging {url}");

        for (int i = 0; i < 5; i++)
        {
            PingReply reply = pingSender.Send(url);

            Console.WriteLine($"{reply.Buffer.Length} bytes from {reply.Address}: " +
                              $"status={reply.Status} time={reply.RoundtripTime}ms");

            Thread.Sleep(500);
        }
    }
}
