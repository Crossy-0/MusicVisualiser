using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public float minThreshold = 0.02f;
    public float frequency = 0.0f;
    public int audioSampleRate = 44100;
    public FFTWindow fftWindow;

    private int samples = 8192;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        UpdateMic();
    }

    void UpdateMic() {
        audioSource.Stop();
        string microphone = Microphone.devices[0];
        audioSource.clip = Microphone.Start(microphone, true, 10, audioSampleRate);
        audioSource.loop = true;

        Debug.Log(Microphone.IsRecording(microphone).ToString());

        if (Microphone.IsRecording(microphone))
        {
            while (!(Microphone.GetPosition(microphone) > 0)) { }
            Debug.Log("Recording Started With " + microphone);

            audioSource.Play();

        }
        else {
            Debug.Log(microphone+" Doesnt Work!");
        
        }

        
    
    }

}
