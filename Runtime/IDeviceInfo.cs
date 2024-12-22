using System.Threading;
using System.Threading.Tasks;

public interface IDeviceInfo
{
    Task<string> GetDeviceModel(CancellationToken token);
	
    Task<int> GetCpuCores(CancellationToken token);
	
    Task<string> GetOsVersion(CancellationToken token);
	
    Task<long> GetDeviceMemory(CancellationToken token);
	
    Task<string> GetDeviceVendor(CancellationToken token);
}