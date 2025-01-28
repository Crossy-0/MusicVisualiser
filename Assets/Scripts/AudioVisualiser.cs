using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualiser : MonoBehaviour
{

    public Transform[] audioSpectrumObjects;
    public float heightMult;
    public int sampleNumber = 1024;
    public FFTWindow fftWindow;
    public float lerpTime = 1.0f;

    private void Update()
    {
        //initialise float array
        float[] spectrum = new float[sampleNumber];

        //fill array with frequency data
        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);

        //loop over spectrumObjects
        for (int i = 0; i < audioSpectrumObjects.Length; i++)
        {

            float intensity = spectrum[i] * heightMult;//getting the audio spectrum for object list pos

            float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
            Vector3 newScale = new Vector3(audioSpectrumObjects[i].localScale.x, lerpY, audioSpectrumObjects[i].localScale.z);
            audioSpectrumObjects[i].localScale = newScale;

        }

    }

}
