using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour
{
    public SpriteRenderer playerSr;

    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        playerSr.enabled = false;
        gameControl.objectives.Remove("Find clothes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
