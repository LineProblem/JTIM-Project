using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeScript : MonoBehaviour
{
    // sprite renderer
    public SpriteRenderer spriteRend;

    // uncomment once in the game
    public PlayerControl player;
    public MoveBox box;

    // fridge open and fridge closed sprites
    public Sprite closedFridge;
    public Sprite openFridge;
    public Sprite emptyFridge;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void interact()
    {
        // player should call this up when interacting with an item.
        if (spriteRend.sprite == openFridge)
        {
            // uncomment once in the actual game
            player.box = box;
            player.holding_box = true;
            box.PickUp();
            box.GetComponentInParent<SpriteRenderer>().sortingOrder = 100;
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