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
        if (playerControl.box == key)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            if (gameControl.objectives.Contains("Enter class on second floor"))
            {
                gameControl.objectives.Remove("Enter class on second floor");
                gameControl.objectives.Add("Find key to room");
                text.text = "The door is locked.";

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
