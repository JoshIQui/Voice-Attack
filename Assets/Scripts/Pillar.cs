using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    Transform tr;

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
        tr.position = new Vector2(tr.position.x, Random.Range(-7, 8));
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector2(tr.position.x - (speed * Time.deltaTime), tr.position.y);

        if (tr.position.x < -15)
        {
            tr.position = new Vector2(15, Random.Range(-7, 8));
        }
    }
}
