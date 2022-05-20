using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    private Transform muzzle;
    public Rigidbody2D rig;

    private PlayerControl playerControl;
    private float grav;




    private bool pickUpAllowed;
    // Use this for initialization
    private void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        grav = rig.gravityScale;
        muzzle = GameObject.Find("Muzzle").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {


    }

    public void PickUp()
    {
        transform.SetParent(muzzle);
        Destroy(rig);
        playerControl.jumpForce = 0;
        playerControl.moveSpeed /= 2;
        transform.localPosition = new Vector3(2.5f, 0, 0);

    }
    public void DropBox()
    {
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody2D>();
        rig = this.GetComponent<Rigidbody2D>();
        playerControl.jumpForce = playerControl.maxJumpForce;
        playerControl.moveSpeed *= 2;
        rig.mass = 100000;
        rig.gravityScale = grav;
        rig.freezeRotation = true;
    }
}
