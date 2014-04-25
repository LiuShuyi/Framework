using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Framework.Network
{
    /// <summary>
    /// NetworkHelper
    /// </summary>
    public static class NetworkHelper
    {
        /// <summary>
        /// GetFirstLocalhostAddress
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <returns></returns>
        public static IPAddress GetFirstLocalhostAddress(AddressFamily addressFamily)
        {
            var addressList = GetLocalhostAddressList(addressFamily);

            if (addressList.Count == 0)
            {
                throw new Exception("IPAddress not found.");
            }

            return addressList[0];
        }

        /// <summary>
        /// GetLocalhostAddressList
        /// </summary>
        /// <param name="addressFamily"></param>
        /// <returns></returns>
        public static List<IPAddress> GetLocalhostAddressList(AddressFamily addressFamily)
        {
            var addressList = new List<IPAddress>();

            var ipEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily.Equals(addressFamily))
                {
                    addressList.Add(ip);
                }
            }

            return addressList;
        }
    }
}
