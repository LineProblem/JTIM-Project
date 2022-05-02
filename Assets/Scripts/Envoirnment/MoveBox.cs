using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    [SerializeField]
    public Transform muzzle;
    public GameObject boxes;
    public Rigidbody2D rig;




    private bool pickUpAllowed;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
      
        
    }

    public void PickUp()
    {
        transform.SetParent(muzzle);
        Destroy(rig);
        transform.localPosition = new Vector3(2.5f, 0, 0);

    }
    public void DropBox()
    {
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody2D>();
        rig = this.GetComponent<Rigidbody2D>();
        rig.mass = 10;
        
        
        
    }

}
