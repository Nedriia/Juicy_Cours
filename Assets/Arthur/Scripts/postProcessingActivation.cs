using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class postProcessingActivation : MonoBehaviour
{
    public PostProcessingBehaviour test;
    public gameManager manager;
    public EnemyBlockManager ennemyGroup;

    //public PostProcessingBehaviour postProcess;
    private ChromaticAberrationModel.Settings Profilsetting;
    private float chroma;

    private void Start()
    {
        test = Camera.main.GetComponent<PostProcessingBehaviour>();
        manager = Camera.main.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var testtest = test.profile.chromaticAberration.settings;
        chroma = manager.multiplicator / 10;
        chroma = Mathf.Clamp(chroma, 0, 2);
        testtest.intensity = chroma;
        test.profile.chromaticAberration.settings = testtest;
    }
}
