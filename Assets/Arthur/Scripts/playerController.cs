using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection
{
    None,
    Right,
    Left
}

public class playerController : MonoBehaviour
{
    [Header("SpaceShip Tweakable Values")]
    public float speed;
    private Vector3 movement;
    private float moveX;

    [Header("SpaceShip Rotation")]
    public AnimationCurve spaceRotationCurve;
    public float rotationTime;
    public float rotationTime_tmp;
    public float maxAngleRotation;
    PlayerDirection playerDirection; 


    [Header("Shot Tweakable Values")]
    public GameObject projectile;
    public float cooldown;
    public float offsetStartingProjectile;
    public float limitX;

    private float timer;
    private bool shooted;

    public CameraShake shakeCamera;
    public Animator animatorPlayer;
    private gameManager manager;

    private void Awake()
    {
        manager = Camera.main.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (transform.position.x < limitX && moveX > 0 || transform.position.x > -limitX && moveX < 0 || moveX == 0)
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
        //transform.Translate(movement * speed * Time.deltaTime);
        transform.position += movement * speed * Time.deltaTime;
        Debug.Log(moveX);
        if (moveX > 0)
        {
            if (playerDirection != PlayerDirection.Right)
            {
                rotationTime_tmp = 0;
            }
            playerDirection = PlayerDirection.Right;
            if (rotationTime_tmp < rotationTime)
            {
                rotationTime_tmp += Time.deltaTime;
            }
            transform.eulerAngles = new Vector3(0, -maxAngleRotation * spaceRotationCurve.Evaluate(rotationTime_tmp / rotationTime), 0);
        }else if (moveX < 0)
        {
            if (playerDirection != PlayerDirection.Left)
            {
                rotationTime_tmp = 0;
            }
            playerDirection = PlayerDirection.Left;
            if (rotationTime_tmp < rotationTime)
            {
                rotationTime_tmp += Time.deltaTime;
            }
            transform.eulerAngles = new Vector3(0, maxAngleRotation * spaceRotationCurve.Evaluate(rotationTime_tmp / rotationTime), 0);
        }else if (moveX == 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    void Fire()
    {
        if(manager.animationEnabled)
            animatorPlayer.Play("shoot");
        if (manager.shake)
        {
            shakeCamera.shakeDuration = 0.1f;
            shakeCamera.Shake();
        }
        ObjectRefs.Instance.soundManager.PlayShoot();
        shooted = true;
        var projectileFired = Instantiate(projectile,new Vector3(transform.position.x, transform.position.y + offsetStartingProjectile),Quaternion.Euler(new Vector3(0,0,90)));
    }
}
