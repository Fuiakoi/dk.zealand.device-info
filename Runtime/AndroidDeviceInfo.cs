using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
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

	public Task<string> GetDeviceModel(CancellationToken token)
	{
		var completion = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			completion?.TrySetCanceled();
		}))
		{
			_bridge.Call("getDeviceModel", new StringListener(val => completion?.TrySetResult(val)));
		}
		return completion.Task;
	}

	public Task<int> GetCpuCores(CancellationToken token)
	{
		var completion = new TaskCompletionSource<int>();
		using (token.Register(() =>
		{
			completion?.TrySetCanceled();
		}))
		{
			_bridge.Call("getCpuCores", new IntListener(
				val => completion?.TrySetResult(val)
			));
		}
		return completion.Task;
	}

	public Task<string> GetOsVersion(CancellationToken token)
	{
		var completion = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			completion?.TrySetCanceled();
		}))
		{
			_bridge.Call("getOsVersion", new StringListener(
				val => completion?.TrySetResult(val)
			));
		}
		return completion.Task;
	}
	
	public Task<long> GetDeviceMemory(CancellationToken token)
	{
		var completion = new TaskCompletionSource<long>();
		using (token.Register(() =>
		{
			completion?.TrySetCanceled();
		}))
		{
			_bridge.Call("getDeviceMemory", new LongListener(
				val => completion?.TrySetResult(val)
			));
		}
		
		return completion.Task;
	}

	public Task<string> GetDeviceVendor(CancellationToken token)
	{
		var completion = new TaskCompletionSource<string>();
		using (token.Register(() =>
		{
			completion?.TrySetCanceled();
		}))
		{
			_bridge.Call("getDeviceVendor", new StringListener(
				val => completion?.TrySetResult(val)
			));
		}
		return completion.Task;
	}
	
	public class StringListener : AndroidJavaProxy
	{
		readonly Action<string> _onSuccess;

		public StringListener(Action<string> onSuccess) : base("dk.zealand.deviceinfo.AndroidDeviceInfo$StringListener")
		{
			_onSuccess = onSuccess;
		}

		[UsedImplicitly]
		void OnSuccess(string val)
		{
			_onSuccess?.Invoke(val);
		}
	}
	
	public class IntListener : AndroidJavaProxy
	{
		readonly Action<int> _onSuccess;

		public IntListener(Action<int> onSuccess) : base("dk.zealand.deviceinfo.AndroidDeviceInfo$IntListener")
		{
			_onSuccess = onSuccess;
		}

		[UsedImplicitly]
		void OnSuccess(int val)
		{
			_onSuccess?.Invoke(val);
		}
	}
	
	public class LongListener : AndroidJavaProxy
	{
		readonly Action<long> _onSuccess;

		public LongListener(Action<long> onSuccess) : base("dk.zealand.deviceinfo.AndroidDeviceInfo$LongListener")
		{
			_onSuccess = onSuccess;
		}

		[UsedImplicitly]
		void OnSuccess(long val)
		{
			_onSuccess?.Invoke(val);
		}
	}
}