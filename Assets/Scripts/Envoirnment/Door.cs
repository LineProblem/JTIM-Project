using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector2 destination;
    public Transform player;
    public CameraScript Camera;
    public Vector2 cameraPos;
    public float newCameraMin;
    public float newCameraMax;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void interact()
    {
        player.position = destination;
        Camera.xMin = newCameraMin;
        Camera.xMax = newCameraMax;
        Camera.GetComponent<Transform>().position = new Vector3(cameraPos.x, cameraPos.y, Camera.transform.position.z);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
