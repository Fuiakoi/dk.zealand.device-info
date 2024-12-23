using AOT;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Scripting;

[Preserve]
public class AppleDeviceInfo : IDeviceInfo
{
#region Native Function declarations

	delegate void StringReceiverDelegate(string val);
	delegate void LongReceiverDelegate(long val);
	delegate void IntReceiverDelegate(int val);
	
	[DllImport("__Internal")]
	private static extern IntPtr __GetDeviceModel(System.IntPtr onReceiveDeviceModelCallback);

	[DllImport("__Internal")]
	private static extern int __GetCpuCores(System.IntPtr onReceiveCpuCoresCallback);

	[DllImport("__Internal")]
	private static extern IntPtr __GetOsVersion(System.IntPtr onReceiveOSVersionCallback);

	[DllImport("__Internal")]
	private static extern long __GetDeviceMemory(System.IntPtr onReceiveDeviceMemoryCallback);

	[DllImport("__Internal")]
	private static extern IntPtr __GetDeviceVendor(System.IntPtr onReceiveDeviceVendorCallback);

#endregion

	//TaskCompletionSource - We use this to get the values from native
	static TaskCompletionSource<string> _deviceModelTcs;
	static TaskCompletionSource<int> _cpuCoresTcs;
	static TaskCompletionSource<string> _osVersionTcs;
	static TaskCompletionSource<long> _deviceMemoryTcs;
	static TaskCompletionSource<string> _deviceVendorTcs;

	public Task<string> GetDeviceModel(CancellationToken token)
	{
		_deviceModelTcs?.TrySetCanceled();
		_deviceModelTcs = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			_deviceModelTcs?.TrySetCanceled();
		}))
		{
			__GetDeviceModel(Marshal.GetFunctionPointerForDelegate<StringReceiverDelegate>(OnReceiveDeviceModel));
		}
		return _deviceModelTcs.Task;
	}

	public Task<int> GetCpuCores(CancellationToken token) 
	{
		_cpuCoresTcs?.TrySetCanceled();
		_cpuCoresTcs = new TaskCompletionSource<int>();
		using (token.Register(() =>
		{
			_cpuCoresTcs?.TrySetCanceled();
		}))
		{
			__GetCpuCores(Marshal.GetFunctionPointerForDelegate<IntReceiverDelegate>(OnReceiveCpuCores));
		}
		return _cpuCoresTcs.Task;
	}

	public Task<string> GetOsVersion(CancellationToken token) 
	{
		_osVersionTcs?.TrySetCanceled();
		_osVersionTcs = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			_osVersionTcs?.TrySetCanceled();
		}))
		{
			__GetOsVersion(Marshal.GetFunctionPointerForDelegate<StringReceiverDelegate>(OnReceiveOsVersion));
		}
		return _osVersionTcs.Task;
	}

	public Task<long> GetDeviceMemory(CancellationToken token)
	{
		_deviceMemoryTcs?.TrySetCanceled();
		_deviceMemoryTcs = new TaskCompletionSource<long>();
		using (token.Register(() =>
		{
			_deviceMemoryTcs?.TrySetCanceled();
		}))
		{
			__GetDeviceMemory(Marshal.GetFunctionPointerForDelegate<LongReceiverDelegate>(OnReceiveDeviceMemory));
		}
		return _deviceMemoryTcs.Task;
	}

	public Task<string> GetDeviceVendor(CancellationToken token)
	{
		_deviceVendorTcs?.TrySetCanceled();
		_deviceVendorTcs = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			_deviceVendorTcs?.TrySetCanceled();
		}))
		{
			__GetDeviceVendor(Marshal.GetFunctionPointerForDelegate<StringReceiverDelegate>(OnReceiveDeviceVendor));
		}
		return _deviceVendorTcs.Task;
	}
	
	// Device model Callback - Called from ObjC++
	[MonoPInvokeCallback(typeof(StringReceiverDelegate))]
	static void OnReceiveDeviceModel(string val)
	{
		_deviceModelTcs?.TrySetResult(val);
	}

	// CPU cores callback - Called from ObjC++
	[MonoPInvokeCallback(typeof(IntReceiverDelegate))]
	static void OnReceiveCpuCores(int val)
	{
		_cpuCoresTcs?.TrySetResult(val);
	}

	// OS version callback - Called from ObjC++
	[MonoPInvokeCallback(typeof(StringReceiverDelegate))]
	static void OnReceiveOsVersion(string val)
	{
		_osVersionTcs?.TrySetResult(val);
	}

	// Device memory callback - Called from ObjC++
    [MonoPInvokeCallback(typeof(LongReceiverDelegate))]
    static void OnReceiveDeviceMemory(long val)
    {
		_deviceMemoryTcs?.TrySetResult(val);
    }
	
	// Device vendor callback - Called from ObjC++
	[MonoPInvokeCallback(typeof(StringReceiverDelegate))]
	static void OnReceiveDeviceVendor(string val)
	{
		_deviceVendorTcs?.TrySetResult(val);
	}
}