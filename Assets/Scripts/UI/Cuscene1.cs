using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Cuscene1 : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Text());

        IEnumerator Text()  //  <-  its a standalone method
        {

            
            yield return new WaitForSeconds(3f);
            Debug.Log("timeup");
            Debug.Log("Restarting");
            SceneManager.LoadScene(scene);

        }
    }

    // Update is called once per frame
    
}
