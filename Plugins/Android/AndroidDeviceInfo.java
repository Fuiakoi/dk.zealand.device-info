package dk.zealand.deviceinfo;

import android.app.Activity;
import android.app.ActivityManager;
import android.content.Context;
import android.os.Build;

public class AndroidDeviceInfo {
    private Activity activity;

    public AndroidDeviceInfo(Activity activity) {
        this.activity = activity;
    }

    public String getDeviceModel() {
        return Build.MODEL;
    }

    public int getCpuCores() {
        return Runtime.getRuntime().availableProcessors();
    }

    public String getOsVersion() {
        return Build.VERSION.RELEASE;
    }

    public long getDeviceMemory() {
        var actManager = (ActivityManager) activity.getSystemService(Context.ACTIVITY_SERVICE);
        ActivityManager.MemoryInfo memInfo = new ActivityManager.MemoryInfo();
        actManager.getMemoryInfo(memInfo);

        return memInfo.totalMem / (1024 * 1024);
    }

    public String getDeviceVendor() {
        return Build.MANUFACTURER;
    }
}