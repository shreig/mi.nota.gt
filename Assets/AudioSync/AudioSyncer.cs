using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;
    public int note;
    public bool averageFrequencies;
    public int nBandsToAverage;

    private float previousAudioValue;
    private float audioValue;
    private float timer;

    private bool isOnBeat;

    public bool IsOnBeat { get => isOnBeat; protected set => isOnBeat = value; }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        previousAudioValue = audioValue;
        if (averageFrequencies)
        {
            audioValue = AvgNote(note) * 100;
        } else {
            audioValue = CommonObjects.audioSpectrumController.Samples[note] * 100;
        }        
        
        if (previousAudioValue > bias && audioValue <= bias || previousAudioValue <= bias && audioValue > bias)
        {
            if (timer > timeStep)
            {
                OnBeat();
            }
        }

        timer += Time.deltaTime;

        if (timer - timeStep > timeToBeat)
        {
            IsOnBeat = false;
        }
    }

    public virtual void OnBeat()
    {
        timer = 0;
        IsOnBeat = true;
    }

    private float AvgNote(int note)
    {
        float noteValue = 0;
        int index;
        int count = 0;
        for (int i = 0; i < nBandsToAverage; i++)
        {
            index = note + i - Mathf.FloorToInt(nBandsToAverage / 2);
            if (index >= 0 && index < CommonObjects.audioSpectrumController.Samples.Length)
            {
                noteValue += CommonObjects.audioSpectrumController.Samples[index];
                count++;
            }
            
        }
        if (count > 0) { 
            return noteValue / count;
        } else
        {
            return 0;
        }
    }
}
