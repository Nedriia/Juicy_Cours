using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class losing : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }

}
