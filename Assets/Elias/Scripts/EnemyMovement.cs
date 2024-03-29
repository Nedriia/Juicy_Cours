﻿using System.Collections;
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
    public GameObject enemyLightExplotion2;
    public float score = 10;
    public float floatingText_MaxSize;
    public float floatingText_MediumSize;
    private CameraShake shake;
    public float waitActivationTime;

    void Start()
    {
        game_ = Camera.main.GetComponent<gameManager>();
        enemyBlockManager = transform.parent.GetComponent<EnemyBlockManager>();
        shake = Camera.main.GetComponent<CameraShake>();
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
            if (game_.shake)
            {
                shake.shakeDuration = 1f;
                shake.Shake_Death();
            }

            if (floatingScore)
            {
                StartCoroutine(waitSeconds(waitActivationTime));
                gameObject.GetComponent<SpriteRenderer>().enabled = false;

                GameObject gameObj_tmp = Instantiate(enemyLightExplotion, transform.position, Quaternion.identity);
                gameObj_tmp.transform.position = new Vector3(gameObj_tmp.transform.position.x, gameObj_tmp.transform.position.y, -6);

                if (game_.particlesActivation)
                    gameObj_tmp = Instantiate(enemyLightExplotion2, transform.position, Quaternion.identity);
            }
            ObjectRefs.Instance.soundManager.PlayExplision();

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
            //Instantiate here
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

    IEnumerator waitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ShowFloatingScore();


        Destroy(gameObject);           
    }

}
