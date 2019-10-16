using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class postProcessingActivation : MonoBehaviour
{
    public PostProcessingBehaviour test;
    public gameManager manager;
    public EnemyBlockManager ennemyGroup;

    public float abberationMax;

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
        chroma = Mathf.Lerp(chroma, manager.multiplicator / 10, Time.deltaTime);
        chroma = Mathf.Clamp(chroma, 0, abberationMax);
        testtest.intensity = chroma;
        test.profile.chromaticAberration.settings = testtest;
    }
}
