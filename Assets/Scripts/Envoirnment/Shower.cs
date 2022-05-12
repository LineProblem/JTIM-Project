using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shower : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    public ParticleSystem particle;
    private GameControl gameControl;
    public AudioSource sound;
    public AudioSource startSound;
    public TextMeshProUGUI text;

    public SpriteRenderer blurSr;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        particle.enableEmission = false;
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        if (blurSr.enabled)
        {
            anim.SetBool("InShower", true);

            sound.Play();
            startSound.Play();
            player.SetActive(false);
            particle.enableEmission = true;

            StartCoroutine(wait());
        }
        else
        {
            text.text = "I can't shower in my clothes";
            StartCoroutine(hideText());
        }
    }
    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(3);
        text.text = "";
        
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
