using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("SpaceShip Tweakable Values")]
    public float speed;
    private Vector3 movement;
    private float moveX;
    public GameObject projectile;

    [Header("Shot Tweakable Values")]
    public float cooldown;
    private float timer;
    private bool shooted;
    public float offsetStartingProjectile;

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Move(moveX);

        if (Input.GetKeyDown(KeyCode.Space) && !shooted)
            Fire();

        if (shooted)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                shooted = false;
            }
        }
    }

    void Move(float MoveX)
    {
        movement.Set(moveX, 0, 0);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Fire()
    {
        shooted = true;
        var projectileFired = Instantiate(projectile,new Vector3(transform.position.x, transform.position.y + offsetStartingProjectile),Quaternion.Euler(new Vector3(0,0,90)));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftCollider" && moveX < 0)
        {
            Debug.Log("left");
            moveX = 0;
        }
        else if (collision.gameObject.name == "RightCollider" && moveX > 0)
        {
            Debug.Log("right");
            moveX = 0;
        }
    }
}
