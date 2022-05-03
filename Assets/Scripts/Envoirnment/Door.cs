using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector2 destination;
    public Transform player;
    public Camera Camera;
    public Vector2 cameraPos;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void interact()
    {
        player.position = destination;
        Camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, Camera.transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
