using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameControl : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI objectiveText;

    [Header("Settings")]
    public float levelTime;
    public List<string> objectives = new List<string>();

    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>();
    }

    public void OnEscapeInput(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Start");
    }


    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        int x = (int)levelTime;
        timeText.text = x.ToString();

        if (objectives.Count > 0)
        {
            objectiveText.text = "Objectives:\n";
            for (int i = 0; i < objectives.Count; i++)
            {
                objectiveText.text += objectives[i] + "\n";
            }
        }
        else
        {
            objectiveText.text = "Objectives complete!";
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (player.transform.position.y < -2)
            {
                objectives.Remove("Get out of room");
            }
            else
            {
                print(player.transform.position.x);
            }
        }
        

        

        if (levelTime < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
