using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("SpaceShip Tweakable Values")]
    private Vector3 movement;
    private float moveX;

    public GameObject projectile;
    public float speed;

    [Header("Shot Tweakable Values")]
    public float cooldown;
    public float offsetStartingProjectile;
    public float limitX;

    private float timer;
    private bool shooted;
    

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (transform.position.x < limitX && moveX > 0 || transform.position.x > -limitX && moveX < 0)
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
}
