# Device information gathering library
This is a package for Unity for retrieving device specific information, like Model, CPU, OS, etc. There exists a GUI for demo/showcasing at [hovedopgave](https://github.com/Fuiakoi/hovedopgave). The package is developed using C# with native plugins in ObjC++ and Java.

## Features
The package has access to the following information:

### Device Model
- Retrieves details about the device model.

### CPU cores
- Retrieves number of CPU cores.

### OS version
- Retrieves operating system and version of OS.

### Device memory
- Retrieves device memory (RAM), showed in megabytes.

### Device Vendor
- Retrieves the unique id for the device.
<br>

Furthermore there is two additional functions:
### Get all info
- Retrieves all the information at the same time.

### Clear all info
- Removes all the information after three seconds.
<br>

### Example usage
Usages could be included as part of a crash report or retrieval to make sure a device meets minimum requirements of a program, app or game.

## Test
There is a single unit test with the package, located in the `/test/playmode/test` folder. It can be run with Unity’s test runner, and it's advised to do so, should there be a need for the test to be run.

## dk.zealand.device-info Installation Guide
This guide outlines the steps to install the `dk.zealand.device-info` Unity package for gathering device information.

## Installation via Unity Package Manager (Git URL)
### Open Unity
- Launch your Unity project.

### Access the Package Manager
- From the Unity Editor, go to the top menu: `Window > Package Manager`.

### Add a Package via Git URL
- In the Package Manager, click the `+` button in the top-left corner.
- Select `Add package` from git URL....
- Paste the following Git URL into the field and press Add:

```git
https://github.com/Fuiakoi/dk.zealand.device-info.git
```

### Verify Installation
- After a few moments, the package will be downloaded and installed. The `dk.zealand.device-info` package should appear in the `Package Manager` list.

## Manual Installation by Editing manifest.json
### Locate the manifest.json File
- Navigate to your Unity project folder.
- Open the Packages directory.
- Locate the `manifest.json` file.

### Edit the manifest.json File
- Open the `manifest.json` file.
- Add the following line to the "dependencies" section:

```git
"dk.zealand.device-info": "https://github.com/Fuiakoi/dk.zealand.device-info.git"
```

Ensure the modified section looks similar to this: <br>
`"dependencies": { …` <br>
`    "dk.zealand.device-info": "https://github.com/Fuiakoi/dk.zealand.device-info.git"` <br>
`}`

### Save and Close
- Save the changes to the `manifest.json` file.
- Close the file.

### Refresh Unity
- Return to the Unity Editor.
- Unity will automatically download and install the package upon detecting the changes in `manifest.json`.

### Verify Installation
- Open `Window > Package Manager` to confirm that `dk.zealand.device-info` is listed.
- The package is now ready to use in your Unity project.

## Technical details
- **Development Platform:** Unity 2022.3.45f1
- **Languages:** C# for backend scripting
- **Cross-platform methods:** Native plugins in Java, ObjC+

## Credits
*Mikkel Elsborg Gregersen*
<br>
*Sofia Mary Møller Mostgaard*
