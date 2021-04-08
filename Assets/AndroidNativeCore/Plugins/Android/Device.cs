using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AndroidNativeCore
{
   public class Device
    {
        //Os Detatils
        public static string androidVersionName()
        {
            AndroidJavaObject obj = new AndroidJavaObject(AndroidCore.PluginPackage + ".Core");
            return  obj.Call<string>("GetVersionName");        
        }
        public static int androidVersionCode()
        {
            AndroidJavaClass version = new AndroidJavaClass("android.os.Build$VERSION");
            return version.GetStatic<int>("SDK_INT");
            }                 
        public static string manfacture()
        {
            AndroidJavaClass version = new AndroidJavaClass("android.os.Build");
            return version.GetStatic<string>("MANUFACTURER");          
        }
        public static string model()
        {
            AndroidJavaClass version = new AndroidJavaClass("android.os.Build");
            return version.GetStatic<string>("MODEL");
            }
        public static string securityPatch()
        {
            AndroidJavaClass version = new AndroidJavaClass("android.os.Build$VERSION");
            return version.GetStatic<string>("SECURITY_PATCH");      
        }
        public static string androidID()
        {
            AndroidJavaClass version = new AndroidJavaClass("android.provider.Settings$Secure");
            return version.CallStatic<string>("getString", AndroidCore.getContext().Call<AndroidJavaObject>("getContentResolver"), version.GetStatic<string>("ANDROID_ID"));
        }

    }
}
