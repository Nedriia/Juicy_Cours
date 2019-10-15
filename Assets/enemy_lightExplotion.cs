using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_lightExplotion : MonoBehaviour
{
    public AnimationCurve angleCurve;
    public float lifeTime;
    public float maxAngle;
    float lifeTime_tmp;
    public List<Color> colors;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Light>().color = colors[Random.Range(0, colors.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime_tmp < lifeTime)
        {
            lifeTime_tmp += Time.deltaTime;
            gameObject.GetComponent<Light>().spotAngle = maxAngle * angleCurve.Evaluate(lifeTime_tmp/lifeTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
