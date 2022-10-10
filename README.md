# unity-mic-example
An example project showing integration of the device microphone in Unity. Device microphone loudness is read and reported to the user every 100 ms. Loudness is also converted to decibels and reported to the user. The following equation is used to convert loudness to decibels: Decibels =  20 * LogBase10(micLoudness).

## Running Locally
Use the following steps to run locally:
1. Clone this repo
2. Open repo folder using Unity 2021.3.11f1
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
- Created using Unity 2021.3.11f1
- Code edited using Visual Studio Code.

## Credits and Links
Unity forum discussion on accessing mic volume:
https://forum.unity.com/threads/check-current-microphone-input-volume.133501/

Unity forum discussion on converting to decibels:
https://answers.unity.com/questions/157940/getoutputdata-and-getspectrumdata-they-represent-t.html?childToView=158800#answer-158800

Stack Overflow discussion on accessing mic decibels:
https://stackoverflow.com/questions/53030560/read-microphone-decibels-and-pitch-frequency

More on decibel range:
https://stackoverflow.com/questions/68099946/why-is-the-volume-coming-from-80db-to-0-not-even-starting-at-0

Understanding 0 decibels:
https://www.quora.com/In-sound-measurement-0-dB-is-the-threshold-of-hearing-but-why-in-digital-audio-mixers-or-in-amplifiers-0-dB-is-referred-as-Maximum-loudness
https://dsp.stackexchange.com/questions/69668/whats-the-minimum-decibel-value

Example project:
https://github.com/devSoyoung/unity-decibel-checker

Decibel overview:
https://www.commodious.co.uk/knowledge-bank/noise/measuring-levels
https://science.howstuffworks.com/question124.htm

Analog vs. Digital:
https://al-ba.com/wp2/understanding-digital-audio-levels-2/

Conversion tool:
http://www.playdotsound.com/portfolio-item/decibel-db-to-float-value-calculator-making-sense-of-linear-values-in-audio-tools/

Technical discussion:
https://answers.unity.com/questions/1395521/why-i-am-getting-negative-decibels-around-70db-whe.html

Convert dBFS to real world:
https://forum.juce.com/t/how-to-convert-decibels-dbfs-to-real-db-spl/36856