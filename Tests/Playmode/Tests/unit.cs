using System.Threading;
using NUnit.Framework;

namespace Tests.Playmode.Tests
{
    [TestFixture]
    public class Unit
    {
        [Test]
        public void Test()
        {
            // Arrange
            var deviceInfo = new EditorDeviceInfo();
            var token = new CancellationToken();

            // Act
            var deviceModel = deviceInfo.GetDeviceModel(token);
            var cpuCores = deviceInfo.GetCpuCores(token);
            var osVersion = deviceInfo.GetOsVersion(token);
            var deviceMemory = deviceInfo.GetDeviceMemory(token);
            var deviceVendor = deviceInfo.GetDeviceVendor(token);

            // Log actual values for debugging
            TestContext.WriteLine($"Device Model: {deviceModel.Result}");
            TestContext.WriteLine($"CPU Cores: {cpuCores.Result}");
            TestContext.WriteLine($"OS Version: {osVersion.Result}");
            TestContext.WriteLine($"Device Memory: {deviceMemory.Result}");
            TestContext.WriteLine($"Device Vendor: {deviceVendor.Result}");

            // Assert
            Assert.IsNotNull(deviceModel.Result);
            Assert.Greater(cpuCores.Result, 0);
            Assert.IsNotNull(osVersion.Result);
            Assert.Greater(deviceMemory.Result, 0);
            Assert.IsNotNull(deviceVendor.Result);
        }
    }
}