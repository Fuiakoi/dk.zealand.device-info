using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using TMPro;
using System;
using System.Collections.Generic;

namespace Tests.Playmode.Tests
{
    [TestFixture]
    public class Stress
    {
        private UiController uiController;
        private GameObject gameObject;
        private Canvas canvas;

        [SetUp]
        public void SetUp()
        {
            // Create canvas for UI elements
            gameObject = new GameObject("TestCanvas");
            canvas = gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasScaler>();
            gameObject.AddComponent<GraphicRaycaster>();

            // Create UiController
            var controllerObject = new GameObject("UiController");
            controllerObject.transform.SetParent(canvas.transform);
            uiController = controllerObject.AddComponent<UiController>();

            // Create TextMeshProUGUI components
            SetupTextMeshProComponents("UnityDeviceModel", out var unityDeviceModelText);
            SetupTextMeshProComponents("UnityCpuCores", out var unityCpuCoresText);
            SetupTextMeshProComponents("UnityOsVersion", out var unityOsVersionText);
            SetupTextMeshProComponents("UnityTotalMemory", out var unityTotalMemoryText);
            SetupTextMeshProComponents("UnityDeviceVendor", out var unityDeviceVendorText);

            SetupTextMeshProComponents("NativeDeviceModel", out var nativeDeviceModelText);
            SetupTextMeshProComponents("NativeCpuCores", out var nativeCpuCoresText);
            SetupTextMeshProComponents("NativeOsVersion", out var nativeOsVersionText);
            SetupTextMeshProComponents("NativeTotalMemory", out var nativeTotalMemoryText);
            SetupTextMeshProComponents("NativeDeviceVendor", out var nativeDeviceVendorText);

            SetupTextMeshProComponents("DeviceModelButton", out var deviceModelButtonText);
            SetupTextMeshProComponents("CpuCoresButton", out var cpuCoresButtonText);
            SetupTextMeshProComponents("OsVersionButton", out var osVersionButtonText);
            SetupTextMeshProComponents("TotalMemoryButton", out var totalMemoryButtonText);
            SetupTextMeshProComponents("DeviceVendorButton", out var deviceVendorButtonText);

            SetupTextMeshProComponents("GetAllInfoButton", out var getAllInfoButtonText);
            SetupTextMeshProComponents("CountdownText", out var countdownText);
            SetupTextMeshProComponents("ClearButton", out var clearButtonText);

            // Create buttons
            SetupButton("DeviceModelButton", out var deviceModelButton);
            SetupButton("CpuCoresButton", out var cpuCoresButton);
            SetupButton("OsVersionButton", out var osVersionButton);
            SetupButton("TotalMemoryButton", out var totalMemoryButton);
            SetupButton("DeviceVendorButton", out var deviceVendorButton);
            SetupButton("GetAllInfoButton", out var getAllInfoButton);
            SetupButton("ClearButton", out var clearButton);

            // Set private fields using reflection
            SetPrivateField(uiController, "unityDeviceModelText", unityDeviceModelText);
            SetPrivateField(uiController, "unityCpuCoresText", unityCpuCoresText);
            SetPrivateField(uiController, "unityOsVersionText", unityOsVersionText);
            SetPrivateField(uiController, "unityTotalMemoryText", unityTotalMemoryText);
            SetPrivateField(uiController, "unityDeviceVendorText", unityDeviceVendorText);

            SetPrivateField(uiController, "nativeDeviceModelText", nativeDeviceModelText);
            SetPrivateField(uiController, "nativeCpuCoresText", nativeCpuCoresText);
            SetPrivateField(uiController, "nativeOsVersionText", nativeOsVersionText);
            SetPrivateField(uiController, "nativeTotalMemoryText", nativeTotalMemoryText);
            SetPrivateField(uiController, "nativeDeviceVendorText", nativeDeviceVendorText);

            SetPrivateField(uiController, "deviceModelButtonText", deviceModelButtonText);
            SetPrivateField(uiController, "cpuCoresButtonText", cpuCoresButtonText);
            SetPrivateField(uiController, "osVersionButtonText", osVersionButtonText);
            SetPrivateField(uiController, "totalMemoryButtonText", totalMemoryButtonText);
            SetPrivateField(uiController, "deviceVendorButtonText", deviceVendorButtonText);

            SetPrivateField(uiController, "getAllInfoButtonText", getAllInfoButtonText);
            SetPrivateField(uiController, "countdownText", countdownText);
            SetPrivateField(uiController, "clearButtonText", clearButtonText);

            SetPrivateField(uiController, "deviceModelButton", deviceModelButton);
            SetPrivateField(uiController, "cpuCoresButton", cpuCoresButton);
            SetPrivateField(uiController, "osVersionButton", osVersionButton);
            SetPrivateField(uiController, "totalMemoryButton", totalMemoryButton);
            SetPrivateField(uiController, "deviceVendorButton", deviceVendorButton);
            SetPrivateField(uiController, "getAllInfoButton", getAllInfoButton);
            SetPrivateField(uiController, "clearButton", clearButton);
        }

        private void SetupTextMeshProComponents(string name, out TextMeshProUGUI text)
        {
            var textObject = new GameObject(name);
            textObject.transform.SetParent(canvas.transform);
            text = textObject.AddComponent<TextMeshProUGUI>();
        }

        private void SetupButton(string name, out Button button)
        {
            var buttonObject = new GameObject(name);
            buttonObject.transform.SetParent(canvas.transform);
            button = buttonObject.AddComponent<Button>();

            // Add TextMeshProUGUI component to button
            var buttonText = new GameObject("Text");
            buttonText.transform.SetParent(buttonObject.transform);
            buttonText.AddComponent<TextMeshProUGUI>();
        }

        private void SetPrivateField(object obj, string fieldName, object value)
        {
            var field = obj.GetType().GetField(fieldName,
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            field?.SetValue(obj, value);
        }

        [UnityTest]
        public IEnumerator StressTestToggleMethods()
        {
            Assert.IsNotNull(uiController, "UiController is null");

            const int testIterations = 100;
            var exceptions = new List<Exception>();

            for (int i = 0; i < testIterations; i++)
            {
                try
                {
                    uiController.ToggleDeviceModel();
                    uiController.ToggleCpuCores();
                    uiController.ToggleOsVersion();
                    uiController.ToggleTotalMemory();
                    uiController.ToggleDeviceVendor();
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                    break;
                }

                yield return null;
            }

            if (exceptions.Count > 0)
            {
                Assert.Fail($"Stress test failed: {exceptions[0].Message}");
            }
            else
            {
                Debug.Log($"Stress test completed successfully with {testIterations} iterations.");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (gameObject != null)
                UnityEngine.Object.Destroy(gameObject);
        }
    }
}