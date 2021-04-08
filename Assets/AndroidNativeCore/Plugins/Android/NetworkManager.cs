using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AndroidNativeCore
{
    public class NetworkManager
    {
        private AndroidJavaObject network;

        public  NetworkManager()
        {
            network = new AndroidJavaObject(AndroidCore.PluginPackage + ".NetworkManager", "2f26/^GK@#73PqNe8a8U");
        }

        public bool isWifiEnabled()
        {
            return network.Call<bool>("isWifiEnabled");
        }
        public bool isWifiConnected()
        {
            return network.Call<bool>("isWifiConnected");

        }
        public bool isMobileDataEnabled()
        {
            return network.Call<bool>("isMobileDataEnabled");
        }

        public void enableWiFi(bool enable)
        {
            network.Call("setWifiEnabled", enable);
        }

        public string IpAddress()
        {
            return network.Call<string>("getIp");

        }
        public string getMacAddress()
        {
            return network.Call<string>("getMac");
        }
        public string getSSID()
        {
            return network.Call<string>("getSsid");
        }
        public string getBSSID()
        {
            return network.Call<string>("getBssd");
        }
        public string getWiFiLinkSpeed()
        {
            return network.Call<string>("getLinkSpeed");
        }

        //Telephone
        public string getTelephoneId()
        {
            return network.Call<string>("getTelephoneId");
        }
        public string getSimSerialNumber()
        {
            return network.Call<string>("getSimSerialNumber");
        }
    }
}
