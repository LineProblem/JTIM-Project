using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClassDoor : MonoBehaviour
{
    private GameControl gameControl;
    private PlayerControl playerControl;
    public MoveBox key;
    public TextMeshProUGUI text;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        gameControl = FindObjectOfType<GameControl>();
        playerControl = FindObjectOfType<PlayerControl>();
    }

    public void interact()
    {
        if (gameControl.objectives.Contains("Enter your first class: Chemistry"))
        {
            gameControl.objectives.Remove("Enter your first class: Chemistry");

        }
        if (playerControl.box == key && gameControl.objectives.Count == 0)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            if (!gameControl.objectives.Contains("Find schedule in office"))
            {
                if (gameControl.objectives.Contains("Find backpack in locker") || !playerControl.backpack.enabled)
                {
                    text.text = "I need my backpack!";
                    StartCoroutine(wait());
                }
                else if (gameControl.objectives.Contains("Find money for the vending machine") || gameControl.objectives.Contains("Get an energy drink from the vending machine"))
                {
                    text.text = "I need more energy";
                    StartCoroutine(wait());
                }
            }

        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
