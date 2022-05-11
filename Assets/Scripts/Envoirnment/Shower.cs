using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public ParticleSystem particle;
    private GameControl gameControl;
    public AudioSource sound;
    public AudioSource startSound;

    // Start is called before the first frame update
    void Start()
    {
        particle.enableEmission = false;
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        anim.SetBool("InShower", true);
        
        sound.Play();
        startSound.Play();
        player.SetActive(false);
        particle.enableEmission = true;

        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(15);
        player.SetActive(true);
        anim.SetBool("InShower", false);
        gameControl.objectives.Remove("Shower");
        particle.enableEmission = false;
        sound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
