using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    public float destroyText = 0.45f;
    private float timer;
    public float sizeAug;

    private gameManager manager;
    public TextMesh sprite;
    // Start is called before the first frame update

    private void Awake()
    {
        manager = Camera.main.GetComponent<gameManager>();
    }

    private void Start()
    {
        sprite = GetComponent<TextMesh>();

    }
    private void Update()
    {
        transform.localScale += new Vector3(sizeAug, sizeAug, 1);
        timer += Time.deltaTime;
        if (manager.multiplicator > 1 && manager.multiplicator < 5)
            sprite.color = new Color(255, 200, 200);
        else if(manager.multiplicator > 5 && manager.multiplicator < 10)
            sprite.color = new Color(255, 100, 100);
        else if(manager.multiplicator > 10 && manager.multiplicator < 15)
            sprite.color = new Color(255, 0, 0);

        if (timer > destroyText)
        {
            Destroy(this.gameObject);
        }
    }

}
