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

    private bool boxGrabbed = false;
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        // player should call this up when interacting with an item.
        if (spriteRend.sprite == openFridge)
        {
            // uncomment once in the actual game
            player.box = box;
            player.holding_box = true;
            box.transform.position = transform.position;
            box.PickUp();
            box.GetComponentInParent<SpriteRenderer>().sortingOrder = 100;
            spriteRend.sprite = emptyFridge;
            boxGrabbed = true;

            // update objective list
            gameControl.objectives.Add("Cook burrito in microwave");
            gameControl.objectives.Remove("Find food in fridge");
        }
        else if (spriteRend.sprite == closedFridge)
        {
            if (!boxGrabbed)
            {
                spriteRend.sprite = openFridge;
            }
            else
            {
                spriteRend.sprite = emptyFridge;
            }
        }
        else if (spriteRend.sprite == emptyFridge)
        {
            spriteRend.sprite = closedFridge;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}