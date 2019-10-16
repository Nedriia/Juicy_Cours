using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion2 : MonoBehaviour
{
    public float delayDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayDestroy -= Time.deltaTime;
        if (delayDestroy < 0)
        {
            Destroy(this);
        }
    }
}
