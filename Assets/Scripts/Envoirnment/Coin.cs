using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerControl player;
    private GameControl gameControl;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        player.money += 1;
        Destroy(gameObject);
        if (gameControl.objectives.Contains("Find money for the vending machine")) ;
        {
            gameControl.objectives.Remove("Find money for the vending machine");
            gameControl.objectives.Add("Get an energy drink from the vending machine");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
