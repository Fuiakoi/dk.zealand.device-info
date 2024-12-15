#import <Foundation/Foundation.h>
#import <sys/utsname.h>
#import <sys/sysctl.h>

extern "C" {
const char GetDeviceModel() {
     struct utsname systemInfo;
     uname(&systemInfo);
     return strdup(systemInfo.machine);
}

int GetCpuCores() {
    int cpuCores;
    size_t len = sizeof(cpuCores);
    sysctlbyname("hw.ncpu", &cpuCores, &len, NULL, 0);
    return cpuCores;
}

const char* GetOsVersion() {
    NSString *osVersion = [[UIDevice currentDevice] systemVersion];
    return strdup([osVersion UTF8String]);
}

int GetDeviceMemory() {
    return (int)([NSProcessInfo processInfo].physicalMemory / (1024 * 1024)); // Convert to MB
}

const char* __GetDeviceVendor() {
    NSString *vendorIdentifier = @"Apple";
    return strdup([vendorIdentifier UTF8String]);
}
}