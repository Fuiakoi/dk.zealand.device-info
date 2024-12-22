using System.Threading;
using System.Threading.Tasks;
using SystemInfo = UnityEngine.Device.SystemInfo;

public class EditorDeviceInfo : IDeviceInfo
{
    public Task<string> GetDeviceModel(CancellationToken token) => Task.FromResult(SystemInfo.deviceModel);

    public Task<int> GetCpuCores(CancellationToken token) => Task.FromResult(SystemInfo.processorCount);

    public Task<string> GetOsVersion(CancellationToken token) => Task.FromResult(SystemInfo.operatingSystem);

    public Task<long> GetDeviceMemory(CancellationToken token) => Task.FromResult((long)SystemInfo.systemMemorySize);
	
    public Task<string> GetDeviceVendor(CancellationToken token) => Task.FromResult(SystemInfo.deviceUniqueIdentifier);
}