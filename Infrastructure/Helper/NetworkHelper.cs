using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Linq;
using System.Net.Sockets;

namespace Infrastructure.Helper
{
    public class NetworkHelper
    {
        /// <summary>
        /// 获取本机所有的IP地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllIpAddresses()
        {
            var interfaces = GetAllNetWorkInterfaces();
            List<string> addresses = new List<string>();
            foreach (var f in interfaces)
            {
                IPInterfaceProperties ip = f.GetIPProperties();
                UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                UnicastIPAddressInformation unicastIpAddressInformation = ipCollection.FirstOrDefault(w => w.Address.AddressFamily == AddressFamily.InterNetwork);
                if (unicastIpAddressInformation == null)
                {
                    unicastIpAddressInformation = ipCollection.FirstOrDefault(w => w.Address.AddressFamily == AddressFamily.InterNetworkV6);
                    if (unicastIpAddressInformation != null)
                    {
                        var ipV4Address = unicastIpAddressInformation.Address.MapToIPv4().ToString();
                        addresses.Add(ipV4Address);
                    }
                }
                else
                {
                    var address = unicastIpAddressInformation.Address.ToString();
                    addresses.Add(address);
                }
            }
            return addresses;
        }

        /// <summary>
        /// 获取可上网的本机IP(剔除虚拟机的IP)
        /// </summary> 
        /// <returns></returns>
        public static string GetLocalIPAddress()
        {
            string result = null;
            NetworkInterface networkInterface = null;
            try
            {
                networkInterface = GetNetworkInterface();
                if (networkInterface != null)
                {
                    IPInterfaceProperties ip = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection ipCollection = ip.UnicastAddresses;
                    UnicastIPAddressInformation unicastIPAddressInformation = ipCollection.FirstOrDefault(w => w.Address.AddressFamily == AddressFamily.InterNetwork);
                    if (unicastIPAddressInformation == null)
                    {
                        unicastIPAddressInformation = ipCollection.FirstOrDefault(w => w.Address.AddressFamily == AddressFamily.InterNetworkV6);
                        result = unicastIPAddressInformation.Address.MapToIPv4().ToString();
                    }
                    else
                    {
                        result = unicastIPAddressInformation.Address.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return result;
        }

        private static NetworkInterface GetNetworkInterface()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface networkInterface = null;

            networkInterface = nics.FirstOrDefault(
                w => w.OperationalStatus == OperationalStatus.Up
            && (w.NetworkInterfaceType == NetworkInterfaceType.Ethernet || w.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            && !w.Description.Contains("VMware")
            && !w.Description.Contains("Bluetooth"));
            return networkInterface;
        }

        private static NetworkInterface GetNetworkInterface(NetworkInterfaceType networkInterfaceType, string networkInterfaceName)
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface networkInterface = null;

            networkInterface = nics.FirstOrDefault(
                w => w.NetworkInterfaceType == networkInterfaceType
                && w.Name == networkInterfaceName
                && w.OperationalStatus == OperationalStatus.Up
                && !w.Description.Contains("VMware")
                && !w.Description.Contains("Bluetooth"));
            return networkInterface;
        }

        private static IEnumerable<NetworkInterface> GetAllNetWorkInterfaces()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            var networkInterface = nics.Where(
                w => w.OperationalStatus == OperationalStatus.Up
                     && (w.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                         w.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                     && !w.Description.Contains("VMware")
                     && !w.Description.Contains("Bluetooth"));
            return networkInterface;
        }
    }
}
