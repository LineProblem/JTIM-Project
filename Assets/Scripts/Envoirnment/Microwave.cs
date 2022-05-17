using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Microwave : MonoBehaviour
{
    public MoveBox box;
    public PlayerControl player;
    public float cookTime;
    private GameControl gameControl;
    public TextMeshProUGUI cookText;

    private AudioSource eatingSnd;

    private bool cooking = false;
    private bool doneCook = false;

    // Start is called before the first frame update
    void Start()
    {
        eatingSnd = GetComponent<AudioSource>();
        cookText.text = "";
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        // if what the player is holding is what can fit in the microwave
        if (player.box == box)
        {
            // stops the player box
            player.holding_box = false;
            player.box = null;
            cooking = true;
            box.DropBox();

            // if anyone knows why the destroy function wasn't working here, that would be helpful to use instead of this
            box.transform.position = new Vector3(-1000, 0, 0);
        }
        if (doneCook)
        {
            eatingSnd.Play();
            gameControl.objectives.Remove("Eat burrito");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking)
        {
            cookTime -= Time.deltaTime;
            int x = (int)cookTime;
            cookText.text = x.ToString();
        }
        if (cookTime < 0)
        {
            cookText.text = "";
            cooking = false;
            doneCook = true;
            cookTime = 100;
            gameControl.objectives.Add("Eat burrito");
            gameControl.objectives.Remove("Cook burrito in microwave");
        }


    }
}