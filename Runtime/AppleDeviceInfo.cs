using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class AppleDeviceInfo : IDeviceInfo
{
    [DllImport("Internal")]
    private static extern IntPtr GetDeviceModel();

    [DllImport("Internal")]
    private static extern int GetCpuCores();

    [DllImport("Internal")]
    private static extern IntPtr GetOsVersion();

    [DllImport("Internal")]
    private static extern int GetDeviceMemory();

    [DllImport("Internal")]
    private static extern IntPtr GetDeviceVendor();

    public string GetDeviceModel()
    {
        IntPtr ptr = GetDeviceModel();
        return Marshal.PtrToStringAnsi(ptr);
    }

    public int GetCpuCores()
    {
        return GetCpuCores();
    }

    public string GetOsVersion()
    {
        IntPtr ptr = GetOsVersion();
        return Marshal.PtrToStringAnsi(ptr);
    }

    public long GetDeviceMemory()
    {
        return GetDeviceMemory();
    }

    public string GetDeviceVendor()
    {
        IntPtr ptr = __GetDeviceVendor();
        return Marshal.PtrToStringAnsi(ptr);
    }
}