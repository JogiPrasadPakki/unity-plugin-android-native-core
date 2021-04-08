using UnityEngine;

namespace AndroidNativeCore
{
    public class Settings{

        #region Settings Id
        public const string ACTION_ACCESSIBILITY_SETTINGS = "android.settings.ACCESSIBILITY_SETTINGS";
        public const string ACTION_ADD_ACCOUNT = "android.settings.ADD_ACCOUNT_SETTINGS";
        public const string ACTION_AIRPLANE_MODE_SETTINGS = "android.settings.AIRPLANE_MODE_SETTINGS";
        public const string ACTION_APN_SETTINGS = "android.settings.APN_SETTINGS";
        public const string ACTION_APPLICATION_DETAILS_SETTINGS = "android.settings.APPLICATION_DETAILS_SETTINGS";
        public const string ACTION_APPLICATION_DEVELOPMENT_SETTINGS = "android.settings.APPLICATION_DEVELOPMENT_SETTINGS";
        public const string ACTION_APPLICATION_SETTINGS = "android.settings.APPLICATION_SETTINGS";
        public const string ACTION_APP_NOTIFICATION_SETTINGS = "android.settings.APP_NOTIFICATION_SETTINGS";
        public const string ACTION_BATTERY_SAVER_SETTINGS = "android.settings.BATTERY_SAVER_SETTINGS";
        public const string ACTION_BLUETOOTH_SETTINGS = "android.settings.BLUETOOTH_SETTINGS";
        public const string ACTION_CAPTIONING_SETTINGS = "android.settings.CAPTIONING_SETTINGS";
        public const string ACTION_CAST_SETTINGS = "android.settings.CAST_SETTINGS";
        public const string ACTION_CHANNEL_NOTIFICATION_SETTINGS = "android.settings.CHANNEL_NOTIFICATION_SETTINGS";
        public const string ACTION_DATA_ROAMING_SETTINGS = "android.settings.DATA_ROAMING_SETTINGS";
        public const string ACTION_DATA_USAGE_SETTINGS = "android.settings.DATA_USAGE_SETTINGS";
        public const string ACTION_DATE_SETTINGS = "android.settings.DATE_SETTINGS";
        public const string ACTION_DEVICE_INFO_SETTINGS = "android.settings.DEVICE_INFO_SETTINGS";
        public const string ACTION_DISPLAY_SETTINGS = "android.settings.DISPLAY_SETTINGS";
        public const string ACTION_DREAM_SETTINGS = "android.settings.DREAM_SETTINGS";
        public const string ACTION_FINGERPRINT_ENROLL = "android.settings.FINGERPRINT_ENROLL";
        public const string ACTION_HARD_KEYBOARD_SETTINGS = "android.settings.HARD_KEYBOARD_SETTINGS";
        public const string ACTION_HOME_SETTINGS = "android.settings.HOME_SETTINGS";
        public const string ACTION_IGNORE_BACKGROUND_DATA_RESTRICTIONS_SETTINGS = "android.settings.IGNORE_BACKGROUND_DATA_RESTRICTIONS_SETTINGS";
        public const string ACTION_IGNORE_BATTERY_OPTIMIZATION_SETTINGS = "android.settings.IGNORE_BATTERY_OPTIMIZATION_SETTINGS";
        public const string ACTION_INPUT_METHOD_SETTINGS = "android.settings.INPUT_METHOD_SETTINGS";
        public const string ACTION_INPUT_METHOD_SUBTYPE_SETTINGS = "android.settings.INPUT_METHOD_SUBTYPE_SETTINGS";
        public const string ACTION_INTERNAL_STORAGE_SETTINGS = "android.settings.INTERNAL_STORAGE_SETTINGS";
        public const string ACTION_LOCALE_SETTINGS = "android.settings.LOCALE_SETTINGS";
        public const string ACTION_LOCATION_SOURCE_SETTINGS = "android.settings.LOCATION_SOURCE_SETTINGS";
        public const string ACTION_MANAGE_ALL_APPLICATIONS_SETTINGS = "android.settings.MANAGE_ALL_APPLICATIONS_SETTINGS";
        public const string ACTION_MANAGE_APPLICATIONS_SETTINGS = "android.settings.MANAGE_APPLICATIONS_SETTINGS";
        public const string ACTION_MANAGE_DEFAULT_APPS_SETTINGS = "android.settings.MANAGE_DEFAULT_APPS_SETTINGS";
        public const string ACTION_MANAGE_OVERLAY_PERMISSION = "android.settings.action.MANAGE_OVERLAY_PERMISSION";
        public const string ACTION_MANAGE_UNKNOWN_APP_SOURCES = "android.settings.MANAGE_UNKNOWN_APP_SOURCES";
        public const string ACTION_MANAGE_WRITE_SETTINGS = "android.settings.action.MANAGE_WRITE_SETTINGS";
        public const string ACTION_MEMORY_CARD_SETTINGS = "android.settings.MEMORY_CARD_SETTINGS";
        public const string ACTION_NETWORK_OPERATOR_SETTINGS = "android.settings.NETWORK_OPERATOR_SETTINGS";
        public const string ACTION_NFCSHARING_SETTINGS = "android.settings.NFCSHARING_SETTINGS";
        public const string ACTION_NFC_PAYMENT_SETTINGS = "android.settings.NFC_PAYMENT_SETTINGS";
        public const string ACTION_NFC_SETTINGS = "android.settings.NFC_SETTINGS";
        public const string ACTION_NIGHT_DISPLAY_SETTINGS = "android.settings.NIGHT_DISPLAY_SETTINGS";
        public const string ACTION_NOTIFICATION_LISTENER_SETTINGS = "android.settings.ACTION_NOTIFICATION_LISTENER_SETTINGS";
        public const string ACTION_NOTIFICATION_POLICY_ACCESS_SETTINGS = "android.settings.NOTIFICATION_POLICY_ACCESS_SETTINGS";
        public const string ACTION_PRINT_SETTINGS = "android.settings.ACTION_PRINT_SETTINGS";
        public const string ACTION_PRIVACY_SETTINGS = "android.settings.PRIVACY_SETTINGS";
        public const string ACTION_QUICK_LAUNCH_SETTINGS = "android.settings.QUICK_LAUNCH_SETTINGS";
        public const string ACTION_REQUEST_IGNORE_BATTERY_OPTIMIZATIONS = "android.settings.REQUEST_IGNORE_BATTERY_OPTIMIZATIONS";
        public const string ACTION_REQUEST_SET_AUTOFILL_SERVICE = "android.settings.REQUEST_SET_AUTOFILL_SERVICE";
        public const string ACTION_SEARCH_SETTINGS = "android.search.action.SEARCH_SETTINGS";
        public const string ACTION_SECURITY_SETTINGS = "android.settings.SECURITY_SETTINGS";
        public const string ACTION_SETTINGS = "android.settings.SETTINGS";
        public const string ACTION_SHOW_REGULATORY_INFO = "android.settings.SHOW_REGULATORY_INFO";
        public const string ACTION_SOUND_SETTINGS = "android.settings.SOUND_SETTINGS";
        public const string ACTION_STORAGE_VOLUME_ACCESS_SETTINGS = "android.settings.STORAGE_VOLUME_ACCESS_SETTINGS";
        public const string ACTION_SYNC_SETTINGS = "android.settings.SYNC_SETTINGS";
        public const string ACTION_USAGE_ACCESS_SETTINGS = "android.settings.USAGE_ACCESS_SETTINGS";
        public const string ACTION_USER_DICTIONARY_SETTINGS = "android.settings.USER_DICTIONARY_SETTINGS";
        public const string ACTION_VOICE_CONTROL_AIRPLANE_MODE = "android.settings.VOICE_CONTROL_AIRPLANE_MODE";
        public const string ACTION_VOICE_CONTROL_BATTERY_SAVER_MODE = "android.settings.VOICE_CONTROL_BATTERY_SAVER_MODE";
        public const string ACTION_VOICE_CONTROL_DO_NOT_DISTURB_MODE = "android.settings.VOICE_CONTROL_DO_NOT_DISTURB_MODE";
        public const string ACTION_VOICE_INPUT_SETTINGS = "android.settings.VOICE_INPUT_SETTINGS";
        public const string ACTION_VPN_SETTINGS = "android.settings.VPN_SETTINGS";
        public const string ACTION_VR_LISTENER_SETTINGS = "android.settings.VR_LISTENER_SETTINGS";
        public const string ACTION_WEBVIEW_SETTINGS = "android.settings.WEBVIEW_SETTINGS";
        public const string ACTION_WIFI_IP_SETTINGS = "android.settings.WIFI_IP_SETTINGS";
        public const string ACTION_WIFI_SETTINGS = "android.settings.WIFI_SETTINGS";
        public const string ACTION_WIRELESS_SETTINGS = "android.settings.WIRELESS_SETTINGS";
        public const string ACTION_ZEN_MODE_PRIORITY_SETTINGS = "android.settings.ZEN_MODE_PRIORITY_SETTINGS";
        public const string AUTHORITY = "settings";
        public const string EXTRA_ACCOUNT_TYPES = "account_types";
        public const string EXTRA_AIRPLANE_MODE_ENABLED = "airplane_mode_enabled";
        public const string EXTRA_APP_PACKAGE = "android.provider.extra.APP_PACKAGE";
        public const string EXTRA_AUTHORITIES = "authorities";
        public const string EXTRA_BATTERY_SAVER_MODE_ENABLED = "android.settings.extra.battery_saver_mode_enabled";
        public const string EXTRA_CHANNEL_ID = "android.provider.extra.CHANNEL_ID";
        public const string EXTRA_DO_NOT_DISTURB_MODE_ENABLED = "android.settings.extra.do_not_disturb_mode_enabled";
        public const string EXTRA_DO_NOT_DISTURB_MODE_MINUTES = "android.settings.extra.do_not_disturb_mode_minutes";
        public const string EXTRA_INPUT_METHOD_ID = "input_method_id";
        public const string EXTRA_SUB_ID = "android.provider.extra.SUB_ID";
        public const string INTENT_CATEGORY_USAGE_ACCESS_CONFIG = "android.intent.category.USAGE_ACCESS_CONFIG";
        public const string METADATA_USAGE_ACCESS_REASON = "android.settings.metadata.USAGE_ACCESS_REASON";

        #endregion

        public void open(string package)
        {
            AndroidJavaObject intentO = new AndroidJavaObject("android.content.Intent",package);          
            AndroidCore.getActivity().Call("startActivityForResult", intentO,0);
        }

    }
}
