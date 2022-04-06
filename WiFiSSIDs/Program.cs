using System;
using System.Linq;
using ManagedNativeWifi;
using System.Collections.Generic;

namespace WiFiSSIDs;

class Program
{
    static void Main()
    {
        EnumerateNetworkSsids().ToList().ForEach(s => Console.WriteLine(s));
    }

    public static IEnumerable<string> EnumerateNetworkSsids()
    {
        return NativeWifi.EnumerateAvailableNetworkSsids().Select(x => x.ToString());       // UTF-8 string representation
    }
}
