# unity-mic-example
An example project showing integration of the device microphone in Unity. Device microphone loudness is read and reported to the user every 100 ms. Loudness is also converted to decibels and reported to the user. The following equation is used to convert loudness to decibels: Decibels =  20 * LogBase10(micLoudness).

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.3f.1
3. Install Text Mesh Pro

## Platform Support
This repo has been tested for use on the following platforms:
- Windows PC
- Android
- iOS

## Android Settings
To get permission to access device features or data outside of your Unity application’s sandbox, there are two stages:
- At build time, declare the permission in the application’s Android App Manifest.
- At runtime, request permission from the user.

For some permissions, Unity automatically handles both the build-time Android App Manifest entries and runtime permission requests. This includes the microphone. For more information, see Unity-handled permissions:

https://docs.unity3d.com/Manual/android-permissions-in-unity.html#unity-handled-permissions

More information on Android permissions here:

https://docs.unity3d.com/Manual/android-permissions-in-unity.html

## iOS Settings
To get permission to access the microphone on iOS, the following is required:
- specify a "microphone usage description" in the build settings.
- At runtime, request permission from the user.

## Development Tools
- Created using Unity 2021.3.3f.1
- Code edited using Visual Studio Code.