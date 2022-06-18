using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerWithoutGenericSingleton : MonoBehaviour
{
    public static AudioManagerWithoutGenericSingleton Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    public void PlayAudio()
    {
    }
}
