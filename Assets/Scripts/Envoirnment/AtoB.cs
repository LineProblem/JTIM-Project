using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtoB : MonoBehaviour
{
    private Transform startPos;
    public Transform target;
    public float speed;
    private bool moveUp;

    void Start()
    {
        startPos.position = transform.position;
        moveUp = true;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (transform.position == target.position)
        {
            moveUp = false;
        }
        else if (transform.position == startPos.position)
        {
            moveUp = true;
        }
        if (moveUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        else if (moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

    }


}
