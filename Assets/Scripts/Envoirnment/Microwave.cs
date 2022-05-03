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
        // if what the player is holding is what can fit in the microwave
        if (player.box == box)
        {
            // stops the player box
            player.holding_box = false;
            box.DropBox();

            // if anyone knows why the destroy function wasn't working here, that would be helpful to use instead of this
            box.transform.position = new Vector3(-1000, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
