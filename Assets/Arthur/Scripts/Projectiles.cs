using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [Header("Projectile tweakable Values")]
    private Rigidbody2D rb;
    public float speed;
    private Vector2 movement = new Vector2(0,1);
    public float sizeX, sizeY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale= new Vector2(sizeX, sizeY);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = movement * speed * Time.deltaTime;    
    }
}
