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
    EnemyDirection enemyDirection;
    EnemyBlockManager enemyBlockManager;
    public gameManager game_;
    public GameObject floatingScore;
    public GameObject enemyLightExplotion;
    public float score = 10;
    public float floatingText_MaxSize;
    public float floatingText_MediumSize;

    void Start()
    {
        game_ = Camera.main.GetComponent<gameManager>();
        enemyBlockManager = transform.parent.GetComponent<EnemyBlockManager>();
    }

    public EnemyDirection GetEnemyDirection()
    {
        return enemyDirection;
    }

    public void SetEnemyDirection(EnemyDirection enemyDirection_)
    {
        enemyDirection = enemyDirection_;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (enemyDirection)
        {
            case EnemyDirection.Down:
                transform.position -= new Vector3(0, enemyBlockManager.getEnemySpeed() * Time.fixedDeltaTime, 0)  * enemyBlockManager.waveFactor;
                break;
            case EnemyDirection.Left:
                transform.position -= new Vector3(enemyBlockManager.getEnemySpeed() * Time.fixedDeltaTime, 0, 0) * enemyBlockManager.waveFactor;
                break;
            case EnemyDirection.Right:
                transform.position += new Vector3(enemyBlockManager.getEnemySpeed() * Time.fixedDeltaTime, 0, 0)  * enemyBlockManager.waveFactor;
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
            if (floatingScore)
            {
                ShowFloatingScore();
            }
  
            GameObject gameObj_tmp = Instantiate(enemyLightExplotion, transform.position, Quaternion.identity);
            gameObj_tmp.transform.position = new Vector3(gameObj_tmp.transform.position.x, gameObj_tmp.transform.position.y, -6);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void ShowFloatingScore()
    {
        if (!game_.float_text)
        {
            game_.killed = true;
            game_.timerMultiplicator = 0;
            game_.multiplicator++;

            floatingScore.GetComponent<TextMesh>().text = "+" + (score * game_.multiplicator).ToString();
            Instantiate(floatingScore, transform.position, Quaternion.identity);

            if (game_.multiplicator > 5)
            {
                floatingScore.transform.localScale = new Vector3(floatingText_MediumSize, floatingText_MediumSize, 1);
            }
            else if (game_.multiplicator > 10)
            {
                floatingScore.transform.localScale = new Vector3(floatingText_MaxSize, floatingText_MaxSize, 1);
            }
        }
    }
}
