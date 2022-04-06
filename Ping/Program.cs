using System.Net.NetworkInformation;

const int TTL = 64;
const int COUNT = 10;
const int BUFFER_LENGTH = 32;
const int TIMEOUT = 1000;

Console.Write("Zadej adresu: ");
string url = Console.ReadLine();

using Ping ping = new();
PingOptions pingOptions = new()
{
    DontFragment = true,
    Ttl = TTL,
};

byte[] buffer = new byte[BUFFER_LENGTH];
Random.Shared.NextBytes(buffer);

for (int i = 0; i < COUNT; i++)
{
    var reply = ping.Send(url, TIMEOUT, buffer, pingOptions);

    if (reply.Status == IPStatus.TimedOut)
    {
        Console.WriteLine($"{i + 1,20}: {reply.Status}");
    }
    else
    {
        Console.WriteLine($"{i + 1,20}: {reply.Status} from {reply.Address} in {reply.RoundtripTime} ms");
    }
}
