using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    private AudioSource snd;
    public int waitTime;
    private PlayerControl player;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        snd = GetComponent<AudioSource>();
        rig = player.GetComponent<Rigidbody2D>();
    }

    public void interact()
    {
        snd.Play();
        player.enabled = false;
        rig.velocity = new Vector3 (0, 0, 0);
        StartCoroutine(wait(waitTime));

    }

    private IEnumerator wait(int wait)
    {
        yield return new WaitForSeconds(wait);
        player.enabled = true;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
