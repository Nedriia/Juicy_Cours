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

    void Start()
    {
        speed = transform.parent.GetComponent<EnemyBlockManager>().enemySpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (enemyDirection)
        {
            case EnemyDirection.Down:
                transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
                break;
            case EnemyDirection.Left:
                transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                break;
            case EnemyDirection.Right:
                transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
                break;
            default:
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftLimit")
        {
            StartCoroutine(transform.parent.GetComponent<EnemyBlockManager>().GoToRight());
        }else if (collision.tag == "RightLimit")
        {
            StartCoroutine(transform.parent.GetComponent<EnemyBlockManager>().GoToLeft());
        }
    }
}
