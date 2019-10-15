using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public float destroyText = 0.45f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject , destroyText);
    }

}
