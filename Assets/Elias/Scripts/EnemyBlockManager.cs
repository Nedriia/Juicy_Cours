using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockManager : MonoBehaviour
{

    public GameObject enemy1;
    public int numEnemies_Vertical, numEnemies_Horizontal;
    public float spaceBetweenEnemyes_Vertical, spaceBetweenEnemyes_Horizontal;
    public List<List<GameObject>> enemyList = new List<List<GameObject>>();
    public float enemySpeed;
    public float downSpaceMovement;
    public bool goingDown;
    public Vector3 downPosition_tmp;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            List<GameObject> list_tmp = new List<GameObject>();
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                GameObject go_tmp = Instantiate(enemy1, transform.position + new Vector3(spaceBetweenEnemyes_Horizontal * x, -spaceBetweenEnemyes_Vertical * y, 0) , Quaternion.identity);
                go_tmp.transform.parent = transform;
                list_tmp.Add(go_tmp);
            }
            enemyList.Add(list_tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goingDown)
        {

        }
    }

    public IEnumerator GoToLeft()
    {
        GoDown();
        yield return new WaitForSeconds(1 / enemySpeed);
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                if (enemyList[x][y] != null)
                {
                    enemyList[x][y].GetComponent<EnemyMovement>().enemyDirection = EnemyDirection.Left;
                }

            }
        }
    }
    public IEnumerator GoToRight()
    {
        GoDown();
        yield return new WaitForSeconds(1/enemySpeed);
        for (int y = 0; y < numEnemies_Vertical; y++)
        {
            for (int x = 0; x < numEnemies_Horizontal; x++)
            {
                if (enemyList[x][y] != null)
                {
                    enemyList[x][y].GetComponent<EnemyMovement>().enemyDirection = EnemyDirection.Right;
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
                    enemyList[x][y].GetComponent<EnemyMovement>().enemyDirection = EnemyDirection.Down;
                }
            }
        }
    }
}
