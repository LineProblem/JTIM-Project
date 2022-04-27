using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Vector2 destination;
    public Transform player;
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.position = destination;
        Camera.transform.position = new Vector3 (20,0,-10);
    }
    public void interact()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
