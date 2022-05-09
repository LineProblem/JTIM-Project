using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidetoside : MonoBehaviour
{
    public Camera cam1;
    public float movespeed = 15;
    public Vector3 targetpos;
    private Vector3 startpos;
    public Vector3 camtarget;

    private bool movingToTarget;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        movingToTarget = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToTarget == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, movespeed * Time.deltaTime);
            if(transform.position == targetpos)
            {
                movingToTarget = false;
                cam1.transform.position = camtarget;
            }
        }
       

    }
}
