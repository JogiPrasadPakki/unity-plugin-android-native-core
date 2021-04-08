using UnityEngine;

namespace AndroidNativeCore
{
    public class Flash
    {
        AndroidJavaObject obj;
        public Flash()
        {
            obj = new AndroidJavaObject(AndroidCore.PluginPackage+".Core");
        }
        public void setFlashEnable(bool enable)
        {
            if (enable)
                obj.Call("FlashOn");
            else
                obj.Call("FlashOff");
        }
        public bool isFlashAvailable()
        {
            return obj.Call<bool>("isFlashAvailable");
        }
    }
}
