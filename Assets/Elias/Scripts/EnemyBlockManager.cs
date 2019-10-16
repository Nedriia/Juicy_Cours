using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockManager : MonoBehaviour
{
    [Header("EnemySpawn")]
    public GameObject enemy1;
    public int numEnemies_Vertical, numEnemies_Horizontal;
    public float spaceBetweenEnemyes_Vertical, spaceBetweenEnemyes_Horizontal;
    List<List<GameObject>> enemyList;

    
    [Header("Speed Modifiers")]
    public float maxSpeed;
    public float minSpeed;
    float enemySpeed;
    public float waveFactor;
    public float downMovementDelay;
    public AnimationCurve speedCurve;

    [Header("References")]
    public GameObject playerRef;
    GameObject enemyRef; // Reference to the last Enemy (the most close to the player)
    float refDistance;

    [Header("EnemyAproaching")]
    public AnimationCurve enymyAproachingcurve;
    public int maxEmisionVal, minEmisionVal;
    public Material EmisionMaterial;
    
    bool delaySpawn = false;

    public float getEnemySpeed()
    {
        return enemySpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        enemyList = new List<List<GameObject>>();
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            List<GameObject> list_tmp = new List<GameObject>();
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                GameObject go_tmp = Instantiate(enemy1, transform.position + new Vector3(spaceBetweenEnemyes_Horizontal * x, -spaceBetweenEnemyes_Vertical * y, 0), Quaternion.identity);
                go_tmp.transform.parent = transform;
                list_tmp.Add(go_tmp);
            }
            enemyList.Add(list_tmp);
        }
        enemyRef = getEnemyRef();
        refDistance = Vector3.Distance(new Vector3(0, playerRef.transform.position.y, 0), new Vector3(0, enemyRef.transform.position.y, 0));
    }

    IEnumerator newWave()
    {
        if (!delaySpawn)
        {
            delaySpawn = true;
            yield return new WaitForSeconds(1);
            EnemySpawn();
            delaySpawn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        enemyRef = getEnemyRef();
        if (enemyRef != null)
        {
            enemySpeed = minSpeed + (maxSpeed - minSpeed) * speedCurve.Evaluate((1 - Vector3.Distance(new Vector3(0, playerRef.transform.position.y, 0), new Vector3(0, enemyRef.transform.position.y, 0)) / refDistance));
        }
        if (transform.childCount == 0)
        {
            StartCoroutine(newWave());
        }

        Debug.Log();
        //RedColor - EnemyAproaching
        EmisionMaterial.SetColor("_EmissionColor", new Vector4((maxEmisionVal - minEmisionVal) * enymyAproachingcurve.Evaluate((1 - Vector3.Distance(new Vector3(0, playerRef.transform.position.y, 0), new Vector3(0, enemyRef.transform.position.y, 0)) / refDistance)), 0, 0 , 255));
    }

    public IEnumerator GoToLeft()
    {
        GoDown();
        yield return new WaitForSeconds(downMovementDelay / enemySpeed);
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                if (enemyList[x][y] != null)
                {
                    enemyList[x][y].GetComponent<EnemyMovement>().SetEnemyDirection(EnemyDirection.Left);
                }

            }
        }
    }
    public IEnumerator GoToRight()
    {
        GoDown();
        yield return new WaitForSeconds(downMovementDelay / enemySpeed);
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                if (enemyList[x][y] != null)
                {
                    enemyList[x][y].GetComponent<EnemyMovement>().SetEnemyDirection(EnemyDirection.Right);
                }
            }
        }
    }

    public void GoDown()
    {
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                if (enemyList[x][y] != null)
                {
                    enemyList[x][y].GetComponent<EnemyMovement>().SetEnemyDirection(EnemyDirection.Down);
                }
            }
        }
    }

    public GameObject getEnemyRef()
    {
        for (int y = numEnemies_Vertical - 1; y >= 0; y--)
        {
            for (int x = numEnemies_Horizontal - 1; x >= 0; x--)
            {
                if (enemyList[x][y] != null)
                {
                    return enemyList[x][y];
                }
            }
        }
        return null;
    }
}
