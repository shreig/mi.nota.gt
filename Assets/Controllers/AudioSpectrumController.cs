using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumController : MonoBehaviour
{
    private float[] samples;
    public const int nSamples = 64;

    public float[] Samples { get => samples; set => samples = value; }

    private void Awake()
    {
        CommonObjects.audioSpectrumController = this;
        Samples = new float[nSamples];
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(Samples, 0, FFTWindow.Hamming);
    }
}
