using System.Net.Sockets;
using System.Net;
using System;

namespace WebIssueManagementApp.Services
{
  public class UtilsService
  {
    private UtilsService() { }

    public static string GetLocalIPAddress()
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());

      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          return ip.ToString();
        }
      }
      throw new Exception("No network adapters with an IPv4 address in the system!");
    }
  }
}
