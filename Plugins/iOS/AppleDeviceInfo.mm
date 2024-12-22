#import <Foundation/Foundation.h>
#import <sys/utsname.h>
#import <sys/sysctl.h>

extern "C" {
    typedef void (*StringReceiverDelegate)(const char* _Null_unspecified str);
    typedef void (*LongReceiverDelegate)(long val);
    typedef void (*IntReceiverDelegate)(int val);
    
    void __GetDeviceModel(StringReceiverDelegate listener) {
        struct utsname systemInfo;
        uname(&systemInfo);
        listener(strdup(systemInfo.machine));
    }
    
    void __GetCpuCores(IntReceiverDelegate listener) {
        int cpuCores;
        size_t len = sizeof(cpuCores);
        sysctlbyname("hw.ncpu", &cpuCores, &len, NULL, 0);
        
        listener(cpuCores);
    }
    
    void __GetOsVersion(StringReceiverDelegate listener) {
        NSString *osVersion = [[UIDevice currentDevice] systemVersion];
        listener(strdup([osVersion UTF8String]));
    }
    
    void __GetDeviceMemory(LongReceiverDelegate listener) {
        listener((long)([NSProcessInfo processInfo].physicalMemory / (1024 * 1024)));
    }
    
    void __GetDeviceVendor(StringReceiverDelegate listener) {
        NSString *vendorIdentifier = [[[UIDevice currentDevice] identifierForVendor] UUIDString];
        listener(strdup([vendorIdentifier UTF8String]));
    }
}
