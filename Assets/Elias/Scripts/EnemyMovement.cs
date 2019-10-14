using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDirection
{
    Left,
    Right,
    Down
}

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public EnemyDirection enemyDirection;
    public EnemyBlockManager enemyBlockManager;

    void Start()
    {
        enemyBlockManager = transform.parent.GetComponent<EnemyBlockManager>();
        speed = transform.parent.GetComponent<EnemyBlockManager>().enemySpeed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (enemyDirection)
        {
            case EnemyDirection.Down:
                transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0) * enemyBlockManager.speedFactor * enemyBlockManager.waveFactor;
                break;
            case EnemyDirection.Left:
                transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0) * enemyBlockManager.speedFactor * enemyBlockManager.waveFactor;
                break;
            case EnemyDirection.Right:
                transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0) * enemyBlockManager.speedFactor * enemyBlockManager.waveFactor;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Left and Right Movement Limits
        if (collision.tag == "LeftLimit")
        {
            StartCoroutine(transform.parent.GetComponent<EnemyBlockManager>().GoToRight());
        }else if (collision.tag == "RightLimit")
        {
            StartCoroutine(transform.parent.GetComponent<EnemyBlockManager>().GoToLeft());
        }

        //Projectile Colliding
        if (collision.tag == "Projectile")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
