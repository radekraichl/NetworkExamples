using System;
using System.IO;
using System.Net;

namespace FtpListing;

class Program
{
    static void Main()
    {
        Uri uri = new(Config.uri);

        if (uri.Scheme != Uri.UriSchemeFtp)
        {
            return;
        }

#pragma warning disable SYSLIB0014 // Type or member is obsolete

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uri);

#pragma warning restore SYSLIB0014 // Type or member is obsolete

        request.Credentials = new NetworkCredential(Config.userName, Config.password);
        request.Method = WebRequestMethods.Ftp.ListDirectory;

        try
        {
            using FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            using Stream publicStream = response.GetResponseStream();
            using StreamReader reader = new(publicStream);

            Console.WriteLine(reader.ReadToEnd());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
