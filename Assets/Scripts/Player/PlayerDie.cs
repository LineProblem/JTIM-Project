using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
public class PlayerDie : MonoBehaviour
{
    public AudioClip die;
    public Animator anim;
    
    public string RestartScene;
    public float curmovinput;

    void Start()
    {

       
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = die;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("death"))
        {
            StartCoroutine(Text());

            IEnumerator Text()  //  <-  its a standalone method
            {
                anim.SetBool("Walking", false);
                GetComponent<PlayerControl>().curMoveInput = 0;
                GetComponent<PlayerControl>().enabled = false;
                anim.SetBool("Death", true);
                GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(6f);
                SceneManager.LoadScene(RestartScene);
               
                
               

            }

        }
    }
}
