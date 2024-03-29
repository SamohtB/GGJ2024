using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundButtonManager : MonoBehaviour
{
    [Serializable]
    struct SoundByte
    {
        public string physicalButton;
        public AudioClip audioClip;
    }

    [SerializeField] private List<SoundByte> soundBytes;
    [SerializeField] private AudioSource audioSource;
    private EnumSoundType answer = EnumSoundType.NONE;

    private bool isTakingInput = false;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playAudioClip(soundBytes[0].audioClip);
            timestampSound("q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            playAudioClip(soundBytes[1].audioClip);
            timestampSound("w");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playAudioClip(soundBytes[2].audioClip);
            timestampSound("e");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            playAudioClip(soundBytes[3].audioClip);
            timestampSound("r");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playAudioClip(soundBytes[4].audioClip);
            timestampSound("a");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playAudioClip(soundBytes[5].audioClip);
            timestampSound("s");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playAudioClip(soundBytes[6].audioClip);
            timestampSound("d");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            playAudioClip(soundBytes[7].audioClip);
            timestampSound("f");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playAudioClip(soundBytes[8].audioClip);
            timestampSound("z");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playAudioClip(soundBytes[9].audioClip);
            timestampSound("x");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playAudioClip(soundBytes[10].audioClip);
            timestampSound("c");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            playAudioClip(soundBytes[11].audioClip);
            timestampSound("v");
        }
    }

    public void uiButton(string physicalButton)
    {
        foreach (SoundByte soundByte in soundBytes)
        {
            if (soundByte.physicalButton == physicalButton)
            {
                playAudioClip(soundByte.audioClip);
                timestampSound(physicalButton);
            }
        }
    }

    public void playAudioClip(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void SetInputTakeable(EnumSoundType correctAnswer)
    {
        isTakingInput = true;
        answer = correctAnswer;
    }

    public void timestampSound(string physicalButton)
    {
        if(isTakingInput && StringToEnum(physicalButton) == answer)
        {
            //add timestamp code here
            //add view counter here
            isTakingInput = false;
            answer = EnumSoundType.NONE;

            DialogueTimer.Instance.FailCheck = false;
            DialogueTimer.Instance.WinCheck = true;
            //FindObjectOfType<ViewerCount>().ChangeViewerCount(false);
            Debug.Log("wow: " + physicalButton);
        }
        
        //FindObjectOfType<ViewerCount>().ChangeViewerCount(true);
    }

    private EnumSoundType StringToEnum(string physicalButton)
    {
        switch(physicalButton) 
        {
            case "q": return EnumSoundType.CENSOR; //Censor

            case "w": case "d": return EnumSoundType.BORING; //Cricket and aughhh or snoring

            case "e":  case "x": return EnumSoundType.FUNNY; //Fart and Vine Boom

            case "r":  case "f": return EnumSoundType.SUS; //Huh and amogus

            case "a":  case "c": return EnumSoundType.HAPPY; //Yippie and noot

            case "s":  case "z": return EnumSoundType.SAD; //Sad trombone and violin

            default: return EnumSoundType.NONE;
        }
    }
}
  