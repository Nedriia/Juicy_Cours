using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losing : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("lose");
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Enemy1")
        {
            Debug.Log("lose");
        }
    }*/

}
