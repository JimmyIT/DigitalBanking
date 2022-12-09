using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Common
{
    public interface IIPAddressProvider
    {
        string GetClientIPAddress();
    }

    public class IPAddressProvider : IIPAddressProvider
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;

        public IPAddressProvider(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public string GetClientIPAddress()
        {
            string ipAddress = string.Empty;

            IPAddress ip = _HttpContextAccessor.HttpContext.Connection.RemoteIpAddress;
            if (ip != null)
            {
                if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                    ip = Dns.GetHostEntry(ip).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);

                ipAddress = ip.ToString();
            }

            return ipAddress;
        }
    }
}
