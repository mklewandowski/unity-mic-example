using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Android;

public class MicInput : MonoBehaviour
{
    public static float MicLoudnessSquared;
    public static float MicLoudnessPos;

    private string _device;

    [SerializeField]
    TextMeshProUGUI LoudnessPosText;
    [SerializeField]
    TextMeshProUGUI LoudnessSquaredText;
    [SerializeField]
    TextMeshProUGUI DecibelPosText;
    [SerializeField]
    TextMeshProUGUI DecibelSquaredText;
    [SerializeField]
    TextMeshProUGUI DecibelsText;

    float levelTimer = 0;
    float levelTimerMax = .1f;

    //mic initialization
    void InitMic()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
        Debug.Log("InitMic");
        if(_device == null) _device = Microphone.devices[0];
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
    }

    void StopMicrophone()
    {
        Microphone.End(_device);
    }

    AudioClip _clipRecord = null;
    int _sampleWindow = 128;

    //get data from microphone into audioclip
    void LevelMax()
    {
        float levelMaxSq = 0;
        float levelMaxPos = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        if (micPosition < 0)
        {
            MicLoudnessSquared = 0;
            MicLoudnessPos = 0;
            return;
        }
        _clipRecord.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeakSq = waveData[i] * waveData[i];
            float wavePeakPos = waveData[i] < 0 ? waveData[i] * -1f : waveData[i];
            if (levelMaxSq < wavePeakSq)
            {
                levelMaxSq = wavePeakSq;
            }
            if (levelMaxPos < wavePeakPos)
            {
                levelMaxPos = wavePeakPos;
            }
        }
        MicLoudnessSquared = levelMaxSq;
        MicLoudnessPos = levelMaxPos;
        // Debug.Log("levelMaxSq: " + levelMaxSq.ToString("F2"));
        // Debug.Log("levelMaxPos: " + levelMaxPos.ToString("F2"));
    }

    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        LevelMax();

        levelTimer -= Time.deltaTime;
        if (levelTimer <= 0)
        {
            LoudnessSquaredText.text = "Mic loudness (0 to 1): " + MicLoudnessSquared.ToString("F4");
            float db = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudnessSquared));
            DecibelSquaredText.text = "Decibels (dBFS): " + db.ToString("F2");

            LoudnessPosText.text = "Mic loudness (0 to 1): " + MicLoudnessPos.ToString("F4");
            float db2 = 20 * Mathf.Log10(Mathf.Abs(MicInput.MicLoudnessPos));
            DecibelPosText.text = "Decibels (dBFS): " + db2.ToString("F2");

            float dbStandard = 96f - Mathf.Abs(10f * Mathf.Log10(Mathf.Abs(MicInput.MicLoudnessPos)));
            DecibelsText.text = "Decibels estimate: " + dbStandard.ToString("F2");

            levelTimer = levelTimerMax;
        }
    }

    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized=true;
    }

    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus) {
        if (focus)
        {
            //Debug.Log("Focus");
            if(!_isInitialized){
                //Debug.Log("Init Mic");
                InitMic();
                _isInitialized=true;
            }
        }
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");
            _isInitialized=false;

        }
    }
}
