public interface IDeviceInfo
{
    string GetDeviceModel();
	
    int GetCpuCores();
	
    string GetOsVersion();
	
    long GetDeviceMemory();
	
    string GetDeviceVendor();
}