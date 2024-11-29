using System.Threading;
using System.Threading.Tasks;
using SystemInfo = UnityEngine.Device.SystemInfo;

public class EditorDeviceInfo : IDeviceInfo
{ 
	public string GetDeviceModel() => SystemInfo.deviceModel;

    public int GetCpuCores() => SystemInfo.processorCount;

    public string GetOsVersion() => SystemInfo.operatingSystem;

    public long GetDeviceMemory() => SystemInfo.systemMemorySize;
	
    public string GetDeviceVendor() => SystemInfo.deviceUniqueIdentifier;
}