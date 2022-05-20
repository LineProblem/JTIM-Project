using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendingScript : MonoBehaviour
{
    private PlayerControl player;
    private bool interacted = false;
    private GameControl gameControl;
    public Animator anim;
    private int moveSpeed;
    private AudioSource snd;


    // Start is called before the first frame update
    void Start()
    {
        snd = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerControl>();
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        if (player.money > 0 && !interacted)
        {
            anim.SetBool("Dispensing", true);
            player.moveSpeed += 2;
            interacted = true;
            if (player.moveSpeed != 0)
            {
                moveSpeed = player.moveSpeed;
                player.moveSpeed = 0;
                StartCoroutine(wait());
            }
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        player.moveSpeed = moveSpeed;
        if (gameControl.objectives.Contains("Get an energy drink from the vending machine"))
        {
            gameControl.objectives.Remove("Get an energy drink from the vending machine");
        }
        snd.Play();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
