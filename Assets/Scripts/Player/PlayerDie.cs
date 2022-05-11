using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerDie : MonoBehaviour
{
    public AudioClip die;
    
    public Animator anim;

    void Start()
    {

        
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = die;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("death"))
        {
            GetComponent<AudioSource>().Play();
            anim.SetBool("Death", true);
        }
    }
}
