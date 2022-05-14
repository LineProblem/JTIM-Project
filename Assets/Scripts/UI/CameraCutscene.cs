using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutscene : MonoBehaviour
{
    private bool waiting = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(.1f);
        waiting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
            GetComponent<Camera>().orthographicSize -= .005f;
    }
}
