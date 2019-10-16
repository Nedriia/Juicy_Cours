using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRefs : MonoBehaviour
{
    public static ObjectRefs Instance { get; private set; }

    public SoundManager soundManager;


    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        if (soundManager == null) { soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>(); }
    }
}
