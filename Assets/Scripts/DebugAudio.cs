using System;
using System.Collections.Generic;
using UnityEngine;


enum SoundTag : int
{
    NONE = -1,
    NORMAL = 0,
    HAPPY, 
    SAD,
    BOOM,
}

public class DebugAudio : MonoBehaviour
{
    [SerializeField] private List<AudioSource> sources;
    //Dictionary<>
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
