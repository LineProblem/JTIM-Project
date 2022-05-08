using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        gameControl = FindObjectOfType<GameControl>();
    }

    public void interact()
    {
        anim.SetBool("InShower", true);

        player.SetActive(false);

        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(15);
        player.SetActive(true);
        anim.SetBool("InShower", false);
        gameControl.objectives.Remove("Shower");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
