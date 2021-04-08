using UnityEngine;
using UnityEditor;
using System;
using System.Xml.Linq;
using System.IO;
using System.Linq;

public class AndroidNativeCoreEditor : EditorWindow {

    private string[] permissions = { "android.permission.ACCESS_NETWORK_STATE", "android.permission.ACCESS_WIFI_STATE", "android.permission.CAMERA", "android.permission.CALL_PHONE", "android.permission.CHANGE_WIFI_STATE", "android.permission.FLASHLIGHT", "android.permission.INTERNET", "android.permission.READ_EXTERNAL_STORAGE", "android.permission.READ_PHONE_STATE", "android.permission.SEND_SMS", "android.permission.VIBRATE", "android.permission.WRITE_EXTERNAL_STORAGE" };
    private bool[] permissions_values = new bool[12];
    private bool notification_support = false;
    private bool isXmlNodeExist;
    private string androidManifestPath;


    private Vector2 scrollPosition;

    private XElement permission_element;
    private XDocument androidManifest;
    XNamespace android = "http://schemas.android.com/apk/res/android";


    [MenuItem("Tools/Android Native Core/Configuration %&A")]
    static void Init()
    {
        AndroidNativeCoreEditor editor = (AndroidNativeCoreEditor)EditorWindow.GetWindow(typeof(AndroidNativeCoreEditor));
        editor.maxSize = new Vector2(400, 500);
        editor.minSize = editor.maxSize;
        editor.Show();
    }
    void OnEnable()
    {

        androidManifestPath = Environment.CurrentDirectory + "/" + @"\Assets\Plugins\Android\AndroidManifest.xml";

        if (File.Exists(androidManifestPath))
        {
            androidManifest = XDocument.Load(androidManifestPath);
            for (int i = 0; i < permissions_values.Length; i++)
            {
                #region Permission values

                switch (i)
                {
                    case 0:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_NETWORK_STATE");                       
                        break;
                    case 1:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_WIFI_STATE");                          
                        break;
                    case 2:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CAMERA");                          
                        break;
                    case 3:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CALL_PHONE");                         
                        break;
                    case 4:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CHANGE_WIFI_STATE");                          
                        break;
                    case 5:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.FLASHLIGHT");                           
                        break;
                    case 6:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.INTERNET");
                        break;
                    case 7:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.READ_EXTERNAL_STORAGE");
                        
                        break;
                    case 8:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.READ_PHONE_STATE");                    
                        break;
                    case 9:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.SEND_SMS");
                        break;
                    case 10:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.VIBRATE");                        
                        break;
                    case 11:
                        permissions_values[i] = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.WRITE_EXTERNAL_STORAGE");
                        break;
                }
                #endregion                
            }
        }
    }

    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Width(400), GUILayout.Height(450));
        GUILayout.Label("Notification support", EditorStyles.boldLabel);
        if(GUILayout.Button("See notification setup guide"))
        {
            Application.OpenURL("https://jogiprasadpakki.github.io/doc/AndroidNativeCore/notification.html");
        }

        GUILayout.Label("Android Resources", EditorStyles.boldLabel);
        GUILayout.Label("Add android drawble files at Assets/Plugins/Android/res/drawable" + "\n" + "Add android sound files at Assets/Plugins/Android/res/raw" +"\n" + "!!!file names should be in lowercase letters,numbers,hyphen only.");
        EditorGUI.EndDisabledGroup();


        GUILayout.Label("Android Permissions", EditorStyles.boldLabel);
        permissions_values[0] = GUILayout.Toggle(permissions_values[0], permissions[0]);
        permissions_values[1] = GUILayout.Toggle(permissions_values[1], permissions[1]);
        permissions_values[2] = GUILayout.Toggle(permissions_values[2], permissions[2]);
        permissions_values[3] = GUILayout.Toggle(permissions_values[3], permissions[3]);
        permissions_values[4] = GUILayout.Toggle(permissions_values[4], permissions[4]);
        permissions_values[5] = GUILayout.Toggle(permissions_values[5], permissions[5]);
        permissions_values[6] = GUILayout.Toggle(permissions_values[6], permissions[6]);
        permissions_values[7] = GUILayout.Toggle(permissions_values[7], permissions[7]);
        permissions_values[8] = GUILayout.Toggle(permissions_values[8], permissions[8]);
        permissions_values[9] = GUILayout.Toggle(permissions_values[9], permissions[9]);
        permissions_values[10] = GUILayout.Toggle(permissions_values[10], permissions[10]);
        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        if (GUILayout.Button("Apply Changes"))
        {
            if (!File.Exists(androidManifestPath))
            {
                //E:\unity\Editor\Data\PlaybackEngines\AndroidPlayer\Apk
                Directory.CreateDirectory(Environment.CurrentDirectory + "/" + @"\Assets\Plugins\Android\");
                File.Copy(Path.GetDirectoryName(EditorApplication.applicationPath) + @"\Data\PlaybackEngines\AndroidPlayer\Apk\AndroidManifest.xml", androidManifestPath);
            }
           androidManifest = XDocument.Load(androidManifestPath);
       
            #region Permissions
            for (int i = 0; i < permissions_values.Length; i++)
            {
                if (permissions_values[i] == true)
                {
                    #region Add Permissions

                    switch (i)
                    {
                        case 0:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_NETWORK_STATE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.ACCESS_NETWORK_STATE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 1:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_WIFI_STATE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.ACCESS_WIFI_STATE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 2:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CAMERA");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.CAMERA"));
                                XElement camera_feature = new XElement("uses-feature", new XAttribute(android + "name", "android.hardware.camera"));
                                androidManifest.Root.Add(permission_element);
                                androidManifest.Root.Add(camera_feature);
                            }
                            break;
                        case 3:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CALL_PHONE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.CALL_PHONE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 4:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CHANGE_WIFI_STATE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.CHANGE_WIFI_STATE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 5:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.FLASHLIGHT");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.FLASHLIGHT"));
                                XElement feature_element = new XElement("uses-feature", new XAttribute(android + "name", "android.hardware.camera.flash"));
                                androidManifest.Root.Add(feature_element);
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 6:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.INTERNET");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.INTERNET"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 9:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.SEND_SMS");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.SEND_SMS"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 10:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.VIBRATE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.VIBRATE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 7:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.READ_EXTERNAL_STORAGE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.READ_EXTERNAL_STORAGE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 11:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.WRITE_EXTERNAL_STORAGE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.WRITE_EXTERNAL_STORAGE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                        case 8:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "aandroid.permission.READ_PHONE_STATE");
                            if (isXmlNodeExist == false)
                            {
                                permission_element = new XElement("uses-permission", new XAttribute(android + "name", "android.permission.READ_PHONE_STATE"));
                                androidManifest.Root.Add(permission_element);
                            }
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region Remove Permissions
                    switch (i)
                    {

                        case 0:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_NETWORK_STATE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.ACCESS_NETWORK_STATE").Remove();
                            }
                            break;
                        case 1:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.ACCESS_WIFI_STATE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.ACCESS_WIFI_STATE").Remove();
                            }
                            break;
                        case 2:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CAMERA");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.CAMERA").Remove();
                                androidManifest.Descendants("uses-feature").Where(x => (string)x.Attribute(android + "name") == "android.hardware.camera").Remove();
                            }
                            break;
                        case 3:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CALL_PHONE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.CALL_PHONE").Remove();
                            }
                            break;
                        case 4:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.CHANGE_WIFI_STATE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.CHANGE_WIFI_STATE").Remove();
                            }
                            break;
                        case 5:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.FLASHLIGHT");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.FLASHLIGHT").Remove();
                                androidManifest.Descendants("uses-feature").Where(x => (string)x.Attribute(android + "name") == "android.hardware.camera.flash").Remove();
                            }
                            break;
                        case 6:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.INTERNET");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.INTERNET").Remove();
                            }
                            break;

                        case 9:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.SEND_SMS");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.SEND_SMS").Remove();
                            }
                            break;
                        case 10:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.VIBRATE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.VIBRATE").Remove();
                            }
                            break;
                        case 7:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.READ_EXTERNAL_STORAGE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.READ_EXTERNAL_STORAGE").Remove();
                            }
                            break;
                        case 11:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.WRITE_EXTERNAL_STORAGE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.WRITE_EXTERNAL_STORAGE").Remove();
                            }
                            break;
                        case 8:
                            isXmlNodeExist = androidManifest.Descendants("uses-permission").Attributes(android + "name").Any(x => x.Value == "android.permission.READ_PHONE_STATE");
                            if (isXmlNodeExist == true)
                            {
                                androidManifest.Descendants("uses-permission").Where(x => (string)x.Attribute(android + "name") == "android.permission.READ_PHONE_STATE").Remove();
                            }
                            break;
                    }
                    #endregion
                }
                androidManifest.Save(androidManifestPath);
            }
            #endregion
        }
    }

    [MenuItem("Tools/Android Native Core/Documentationn")]
    static void doc()
    {
        Application.OpenURL("https://jogiprasadpakki.github.io/doc/AndroidNativeCore/AndroidNativeCore.html");
    }
}
