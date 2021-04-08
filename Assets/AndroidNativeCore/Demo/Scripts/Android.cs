using AndroidNativeCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Android : MonoBehaviour {

    public Texture2D NotifiBigIcon;
    public Text flashText;
    public Text DeviceInfo;
    public Image resultImage;
    public GameObject devicePanel;
    public GameObject inputFieldObject;
    public InputField url;
    private long[] vibratePattren = {0,100,1000 };
    private bool flashOn,isInputFieldActive = false;
    private NetworkManager networkManager;

    Flash flash;

    void Start()
    {
        flash = new Flash();
        networkManager = new NetworkManager();
        Notification.Channel c = new Notification.Channel();
        c.CreateChannel("notification_0", "Game Notifications", "Notifications about game level score and high scores.", Notification.Channel.IMPORTANCE_MAX, Notification.Channel.VISIBILITY_PRIVATE, true, "#ffff", true, true);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AlertDialog alert = new AlertDialog();
            alert.build(AlertDialog.THEME_HOLO_DARK)
           .setTitle("Exit..?")
           .setMessage("Are you sure to exit..?")
           .setIcon("icon_warning")
           .setNegativeButtion("Return", () => { alert.dismiss(); })
           .setPositiveButtion("exit", () => { Application.Quit(); })
           .show();
        }
            
    }

    public void deviceInfo()
    {
        devicePanel.SetActive(true);
        string info ="---Device Info---@Manfacuturer: "+Device.manfacture()+"@"+ "Device Id: "+Device.androidID()+"@" +"Model: "+Device.model()+"@"+"Android Version Name: "+Device.androidVersionName()+"@"+"Android version code: "+Device.androidVersionCode()+"@"+"Security Patch: "+Device.securityPatch()+"@ @"+
            "@---Wifi Info--@Is wifi Enabled: " + networkManager.isWifiEnabled()+"@Is wifi Connected: "+networkManager.isWifiConnected()+"@IP Address: "+networkManager.IpAddress()+"@Mac Address: "+networkManager.getMacAddress()+"@@---Telephone Info---@Is Mobile data enabled: "+networkManager.isMobileDataEnabled()+"@Telephone Id: "+networkManager.getTelephoneId() + "@Sim serial number: " + networkManager.getSimSerialNumber();
        string device_info = info.Replace("@", System.Environment.NewLine);
        DeviceInfo.text = device_info;
    }
 
    public void toast()
    {
        Toast.make("hi android native core", Toast.LENGTH_SHORT);
    }

    public void AlertGeneral()
    {
        AlertDialog alert = new AlertDialog();
        alert.build(AlertDialog.THEME_TRADITIONAL)
       .setTitle("Hi")
       .setIcon("alert_icon")
       .setMessage("This is traditional Alert dialog")
       .setNegativeButtion("Cansel", () => { Toast.make("Negative btn clicked",Toast.LENGTH_SHORT); alert.dismiss(); })
       .setPositiveButtion("Ok", () => { Toast.make("Positive btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .show();   
    }
    public void AlertHoloDark()
    {
        AlertDialog alert = new AlertDialog();
        alert.build(AlertDialog.THEME_HOLO_DARK)
       .setTitle("Hi")
       .setMessage("This is Holo Dark Alert dialog")
       .setIcon("alert_icon")
       .setNegativeButtion("Cansel", () => { Debug.Log("Negitive btn clicked"); Toast.make("Negative btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .setPositiveButtion("Ok", () => { Toast.make("Positive btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .show();
    }
    public void AlertHoloLight()
    {
        AlertDialog alert = new AlertDialog();
        alert.build(AlertDialog.THEME_HOLO_LIGHT)
       .setTitle("Hi")
       .setMessage("This is Holo Light Alert dialog")
       .setNegativeButtion("Cansel", () => { Toast.make("Negative btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .setPositiveButtion("Ok", () => { Toast.make("Positive btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .show();
    }
    public void AlertDeviceDark()
    {
        AlertDialog alert = new AlertDialog();
        alert.build(AlertDialog.THEME_DEVICE_DEFAULT_DARK)
       .setTitle("Hi")
       .setMessage("This is Device default Dark Alert dialog")
       .setNegativeButtion("Cansel", () => { Toast.make("Negative btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .setPositiveButtion("Ok", () => { Toast.make("Positive btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .show();
    }
    public void AlertDeviceLight()
    {
        AlertDialog alert = new AlertDialog();
        alert.build(AlertDialog.THEME_DEVICE_DEFAULT_LIGHT)
       .setTitle("Hi")
       .setMessage("This is Device default light Alert dialog")
       .setNegativeButtion("Cansel", () => { Toast.make("Negative btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .setPositiveButtion("Ok", () => { Toast.make("Positive btn clicked", Toast.LENGTH_SHORT); alert.dismiss(); })
       .show();
    }

    public void NotificationBigImage()
    {
        Notification notfi = new Notification();
        notfi.Create("notification_0")
            .setContentTitle("Android Native Core")
            .setContentText("this notification with bigImage")
            .setIcon("android_native_core")
            .setDefautlSound()
            .setPriority(Notification.PRIORITY_MAX)
            .setBigImage(NotifiBigIcon)
            .notify(1);
    }

    public void toggleInputField()
    {
        if (!isInputFieldActive)
        {
            inputFieldObject.SetActive(true);
            isInputFieldActive = true;
        }
        else
        {
            inputFieldObject.SetActive(false);
            isInputFieldActive = false;
        } 

        
    }
    public void NotificationBigUrl()
    {
        inputFieldObject.SetActive(false);
        Notification notfi = new Notification();
        notfi.Create("notification_0")
            .setIcon("android_native_core")
            .setContentTitle("Android Native Core")
            .setBigText("this is notification image from url")
            .setSound("notification_sound")
            .setPriority(Notification.PRIORITY_MAX)
            .setBigImage(url.text)
            .notify(2);
    }

    public void deviceFlash()
    {
        if (!flashOn)
        {
            flashOn = true;
            flash.setFlashEnable(true);
            flashText.text = "Flash Off";
        }
        else
        {
            flashOn = false;
            flash.setFlashEnable(false);
            flashText.text = "Flash On";
        }
    }

    public void vibrate()
    {
        Vibrator.Vibrate(500);
    }
    public void vibratorPattren()
    {
        Vibrator.Vibrate(vibratePattren,0);
    }
    public void vibrateCansel()
    {
        Vibrator.Cansel();
    }

    public void datePicker()
    {
        Pickers Pickers = new Pickers();
        Pickers.pickDate(8, 11, 2018, (int d, int m, int y) => { Toast.make("Picked date: "+d.ToString()+"/"+m.ToString()+"/"+y.ToString(),Toast.LENGTH_SHORT); });
    }
    public void TimePicker()
    {
        Pickers Pickers = new Pickers();
        Pickers.pickTime(8, 46, false, (int h, int m) => { Toast.make("Picked Time: " + h.ToString() + ":" + m.ToString(), Toast.LENGTH_SHORT); });
    }
    public void cameraPicker()
    {
        Pickers Pickers = new Pickers();
        Pickers.pickImageFromCamera((string path) =>
        {
            byte[] img;
            Debug.Log(path);
            img = File.ReadAllBytes(path);
            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(img);
            resultImage.sprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
        },()=> { });
    }
    public void galleryPicker()
    {
        
        Pickers Pickers = new Pickers();
        Pickers.pickImageFromGallery((string path) =>
        {
            byte[] img;
            Debug.Log(path);
            img = File.ReadAllBytes(path);
            Texture2D t = new Texture2D(1, 1);
            t.LoadImage(img);
            resultImage.sprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
        },()=> { });
    }

    public void Call()
    {
        AndroidCore.MakeCall("123456789");
    }
    public void dail(){
        AndroidCore.Dial("123456789");
    }
    public void message()
    {
        AndroidCore.ComposeMessage("123456789", "This message composed from Android Native Core Unity Plugin");
    }
    public void mail()
    {
        AndroidCore.ComposeMail("user@example.com", "Android Native Core Demo", "This mail composed from Android Native Core Unity Plugin");
    }
    public void share()
    {
        AndroidCore.Share("Get Android Native Feature in unity game with Android Native Core", NotifiBigIcon); 
    }

    public void closeDeviceInfo()
    {
        devicePanel.SetActive(false);
    }
    public void openYoutube()
    {
        AndroidCore.openApplicationView("vnd.youtube:kyD0q57zw40");
    }
    public void openSettings()
    {
        Settings settings = new Settings();
        settings.open(Settings.ACTION_WIFI_SETTINGS);
    }
}
