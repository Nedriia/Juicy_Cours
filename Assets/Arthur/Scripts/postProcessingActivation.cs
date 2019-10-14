using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class postProcessingActivation : MonoBehaviour
{
    public PostProcessingBehaviour test;

    //public PostProcessingBehaviour postProcess;
    private ChromaticAberrationModel.Settings Profilsetting;
    private float chroma;

    private void Start()
    {
        test = Camera.main.GetComponent<PostProcessingBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var testtest = test.profile.chromaticAberration.settings;
            chroma += 0.5f * Time.deltaTime;
            testtest.intensity = chroma;
            test.profile.chromaticAberration.settings = testtest;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            var testtest = test.profile.chromaticAberration.settings;
            chroma -= 0.5f * Time.deltaTime;
            testtest.intensity = chroma;
            test.profile.chromaticAberration.settings = testtest;
        }
    }
}
