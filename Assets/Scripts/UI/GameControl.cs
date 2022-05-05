using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI objectiveText;

    [Header("Settings")]
    public float levelTime;
    public List<string> objectives = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelTime -= Time.deltaTime;
        int x = (int)levelTime;
        timeText.text = x.ToString();

        objectiveText.text = "Objectives:\n";
        for (int i = 0; i < objectives.Count; i++)
        {
            objectiveText.text += objectives[i] + "\n";
        }
        

        if (levelTime < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
