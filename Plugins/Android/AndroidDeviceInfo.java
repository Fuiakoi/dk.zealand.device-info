package dk.zealand.deviceinfo;

import android.app.Activity;
import android.app.ActivityManager;
import android.content.Context;
import android.os.Build;
import android.provider.Settings;

import java.math.BigInteger;
import java.nio.charset.StandardCharsets;
import java.security.*;

public class AndroidDeviceInfo{
    private Activity activity;

    public AndroidDeviceInfo(Activity activity) {
        this.activity = activity;
    }

    public void getDeviceModel(StringListener listener) {
        listener.OnSuccess(Build.MODEL);
    }

    public void getCpuCores(IntListener listener) {
        listener.OnSuccess(Runtime.getRuntime().availableProcessors());
    }

    public void getOsVersion(StringListener listener) {
        listener.OnSuccess(Build.VERSION.RELEASE);
    }

    public void getDeviceMemory(LongListener listener) {
        var actManager = (ActivityManager) activity.getSystemService(Context.ACTIVITY_SERVICE);
        ActivityManager.MemoryInfo memInfo = new ActivityManager.MemoryInfo();
        actManager.getMemoryInfo(memInfo);

        listener.OnSuccess(memInfo.totalMem / (1024 * 1024));
    }

    public void getDeviceVendor(StringListener listener) throws NoSuchAlgorithmException {
        var androidId = Settings.Secure.getString(activity.getContentResolver(), Settings.Secure.ANDROID_ID);

        var bytesOfId = androidId.getBytes(StandardCharsets.UTF_8);

        MessageDigest md = MessageDigest.getInstance("MD5");
        byte[] hashedBytes = md.digest(bytesOfId);

        var encodedId = toHex(hashedBytes);

        listener.OnSuccess(encodedId);
    }
    
    public interface StringListener {
        void OnSuccess(String val);
    }

    public interface IntListener {
        void OnSuccess(int val);
    }

    public interface LongListener {
        void OnSuccess(long val);
    }

    public static String toHex(byte[] bytes) {
        BigInteger bi = new BigInteger(1, bytes);
        return String.format("%0" + (bytes.length << 1) + "x", bi);
    }
}