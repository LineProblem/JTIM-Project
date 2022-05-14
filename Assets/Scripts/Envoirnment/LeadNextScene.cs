using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeadNextScene : MonoBehaviour
{
    public AudioClip die;    // Add your Audi Clip Here;
   
   
                             // MAke Sure You added AudioSouce to death Zone;
    void Start()
    {
        
       
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = die;
    }
    

    public Scene currentScene;
        public string sceneName ;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {

            StartCoroutine(Text());

            IEnumerator Text()  //  <-  its a standalone method
            {

              GetComponent<AudioSource>().Play();
              yield return new WaitForSeconds(1.2f);
              Debug.Log("timeup");
              Debug.Log("Restarting");
                if (sceneName == "cutscene 5" && PlayerPrefs.GetInt("Unlocked") == 2)
                {
                    PlayerPrefs.SetInt("Unlocked", 3);
                }
                PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(sceneName);
                
            }

            
        }
        
      
    }
}
