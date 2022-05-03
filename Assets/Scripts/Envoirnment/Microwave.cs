using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microwave : MonoBehaviour
{
    public MoveBox box;
    public PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void interact()
    {
        if (player.box == box)
        {
            print("Start microwave");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
