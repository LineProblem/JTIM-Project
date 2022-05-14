using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorLevelOne : MonoBehaviour
{
    public SpriteRenderer fridgeSr;
    private Sprite closedFridge;
    public TextMeshProUGUI commentText;
    public string nextScene;
    private GameControl gameControl;

    // Start is called before the first frame update
    void Start()
    {
        closedFridge = fridgeSr.sprite;
        commentText.text = "";
        gameControl = FindObjectOfType<GameControl>();
    }
    
    private IEnumerator showText(string message)
    {
        commentText.text = message;
        yield return new WaitForSeconds(3);
        commentText.text = "";
    }

    public void interact()
    {
        print("interact");
        if (gameControl.objectives.Count > 0)
        {
            if (gameControl.objectives.Contains("Find clothes"))
            {
                StartCoroutine(showText("I need to get clothes!"));
            }
            else if (gameControl.objectives.Contains("Shower"))
            {
                StartCoroutine(showText("I need to shower!"));
            }
            else
            {
                StartCoroutine(showText("I need to eat!"));

            }
        }
        else
        {
            if (closedFridge = fridgeSr.sprite)
            {
                if (PlayerPrefs.GetInt("Unlocked") == 1)
                {
                    PlayerPrefs.SetInt("Unlocked", 2);
                }
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                StartCoroutine(showText("I need to close my fridge!"));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
