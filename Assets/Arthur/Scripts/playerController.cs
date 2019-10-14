using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    public float moveX;

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Move(moveX);

        if (Input.GetKey(KeyCode.Space))
            Fire();
    }

    void Move(float MoveX)
    {
        movement.Set(moveX, 0, 0);
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Fire()
    {

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
