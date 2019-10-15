using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionCode2D.Renderers;

public class gameManager : MonoBehaviour
{
    public float multiplicator;
    public bool killed;
    public float timerMultiplicator, TotalTime;

    public SpriteGhostTrailRenderer ghostEffect;
    public postProcessingActivation postProcess;
    public bool float_text;

    private float chroma;

    private void Update()
    {
        if(killed)
        {
            timerMultiplicator += Time.deltaTime;
            if(timerMultiplicator > TotalTime)
            {
                killed = false;
                multiplicator = 1;
                timerMultiplicator = 0;
            }
        }
        //1 - Sprite Effect
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(ghostEffect.enabled)
            {
                ghostEffect.enabled = false;
            }            
            else{
                ghostEffect.enabled = true;
            }
        }

        //2 - Aberration Effect
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (postProcess.enabled)
            {
                var testtest = postProcess.test.profile.chromaticAberration.settings;
                chroma = 0;
                testtest.intensity = chroma;
                postProcess.test.profile.chromaticAberration.settings = testtest;
                postProcess.enabled = false;
            }
            else
            {
                postProcess.enabled = true;
            }
        }

        //3 - Score desactivation
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (float_text == false)
            {
                float_text = true;
            }
            else if(float_text == true)
            {
                float_text = false;
            }
        }
    }
}
