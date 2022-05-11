using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiolet : MonoBehaviour
{
    public AudioSource sound;
    private PlayerControl player;
    private int moveSpeed;
    public SpriteRenderer sr;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        particle.enableEmission = false;
        player = FindObjectOfType<PlayerControl>();
    }

    public void interact()
    {
        moveSpeed = player.moveSpeed;
        player.moveSpeed = 0;
        particle.enableEmission = true;
        sr.enabled = true;
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        particle.enableEmission = false;
        player.moveSpeed = moveSpeed;
        sr.enabled = false;
        sound.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
