using System.Net;
using System.Net.NetworkInformation;

const int MAX_TTL = 64;
const int BUFFER_LENGTH = 32;
const int TIMEOUT = 1000;

Console.Write("Zadej adresu: ");
string url = Console.ReadLine();

using Ping ping = new();
PingOptions pingOptions = new()
{
    DontFragment = true,
    Ttl = 1,
};

byte[] buffer = new byte[BUFFER_LENGTH];
Random.Shared.NextBytes(buffer);

for (int i = 0; i < MAX_TTL; i++)
{
    var reply = ping.Send(url, TIMEOUT, buffer, pingOptions);

    if (reply.Status == IPStatus.TimedOut)
    {
        Console.WriteLine($"{i + 1,20}: {reply.Status}");
    }
    else
    {
        Console.WriteLine($"{i + 1,20}: {reply.Status} from {GetHostName(reply.Address)} in {reply.RoundtripTime} ms");

        if (reply.Status == IPStatus.Success)
        {
            break;
        }
    }

    pingOptions.Ttl++;
}

static string GetHostName(IPAddress ip)
{
    try
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
        return $"{ip} [{hostEntry.HostName}]";
    }
    catch (System.Net.Sockets.SocketException)
    {
        return ip.ToString();
    }
}
