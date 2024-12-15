using UnityEngine;

public class AndroidDeviceInfo : IDeviceInfo
{
    private AndroidJavaObject _bridge;

    public AndroidDeviceInfo()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        _bridge = new AndroidJavaObject("dk.zealand.deviceinfo.AndroidDeviceInfo", currentActivity);
    }

    public string GetDeviceModel()
    {
        return _bridge.Call<string>("getDeviceModel");
    }

    public int GetCpuCores()
    {
        return _bridge.Call<int>("getCpuCores");
    }

    public string GetOsVersion()
    {
        return _bridge.Call<string>("getOsVersion");
    }

    public long GetDeviceMemory()
    {
        return _bridge.Call<long>("getDeviceMemory");
    }

    public string GetDeviceVendor()
    {
        return _bridge.Call<string>("getDeviceVendor");
    }
}