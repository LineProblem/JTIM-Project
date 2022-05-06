using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    private float speed;
    public BoxCollider2D col;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 6);
        speed /= 100;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.localScale += new Vector3(speed, speed, 0);
        transform.position += new Vector3(0, speed / 4, 0);

        if (transform.localScale.x > 2)
        {
            col.enabled = true;
            if (transform.localScale.x > 3)
            {
                transform.localScale = new Vector3(0, 0, 1);
                transform.position = startPos;
                speed = Random.Range(1, 6);
                speed /= 100;
                col.enabled = false;
            }
        }
    }
}
