using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendingScript : MonoBehaviour
{
    private PlayerControl player;
    private bool interacted = false;
    private GameControl gameControl;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        if (player.money > 0 && !interacted)
        {
            player.moveSpeed += 2;
            interacted = true;
            if (gameControl.objectives.Contains("Get an energy drink from the vending machine"))
            {
                gameControl.objectives.Remove("Get an energy drink from the vending machine");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
