using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    public SpriteRenderer spriteRend;

    public Sprite closedFridge;
    public Sprite openFridge;
    public Sprite emptyFridge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void interact()
    {
        if (spriteRend.sprite == openFridge)
        {
            spriteRend.sprite = emptyFridge;
           
        }
        else if (spriteRend.sprite == closedFridge)
        {
            spriteRend.sprite = openFridge;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
