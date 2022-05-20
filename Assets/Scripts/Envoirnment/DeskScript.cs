using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskScript : MonoBehaviour
{
    private GameControl gameControl;


    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        if (gameControl.objectives.Contains("Find schedule in office"))
        {
            gameControl.objectives.Remove("Find schedule in office");
            gameControl.objectives.Add("Enter your first class: Chemistry");
            gameControl.objectives.Add("Find backpack in locker");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
