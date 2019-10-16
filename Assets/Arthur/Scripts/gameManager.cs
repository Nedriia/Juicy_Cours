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
    public playerController player;
    public SoundManager sound;
    
    public bool float_text;

    private float chroma;

    public bool shake = true;
    public bool animationEnabled = true;
    public bool particlesActivation = true;

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

        //4 -Camera Shake
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (shake == false)
            {
                shake = true;
            }
            else if (shake == true)
            {
                shake = false;
            }
        }

        //5 - Animation player
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            if(animationEnabled == false)
            {
                animationEnabled = true;
            }
            else if(animationEnabled == true)
            {
                animationEnabled = false;
            }
        }

        //6- Sound
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (sound.SoundActive == false)
            {
                sound.SoundActive = true;
            }
            else if (sound.SoundActive == true)
            {
                sound.SoundActive = false;
            }
        }

        //7- Trail
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (player.projectile.GetComponent<Projectiles>().GetComponent<TrailRenderer>().enabled == false)
            {
                player.projectile.GetComponent<Projectiles>().GetComponent<TrailRenderer>().enabled  = true;
            }
            else if (player.projectile.GetComponent<Projectiles>().GetComponent<TrailRenderer>().enabled == true)
            {
                player.projectile.GetComponent<Projectiles>().GetComponent<TrailRenderer>().enabled = false;
            }
        }

        //8- Particules
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (particlesActivation == false)
            {
                particlesActivation = true;
            }
            else if (particlesActivation == true)
            {
                particlesActivation = false;
            }
        }
    }
}
