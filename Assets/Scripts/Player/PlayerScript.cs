using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Settings")]
    public int moveSpeed;
    public float jumpForce;
    public int maxJumps;
    public bool can_pickup;
    private MoveBox box;
    private MoveBox heldBox;
    private bool holding_box;

    [Header("Components")]
    public Rigidbody2D rig;
    public Collider2D muzzle;


    // private variables
    private int curJumps;
    private float curMoveInput;



    // Start is called before the first frame update
    void Start()
    {
        curJumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].point.y < transform.position.y)
        {
            curJumps = maxJumps;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("hit box");
            box = collision.gameObject.GetComponent<MoveBox>();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            box = null;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
           
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(curMoveInput * moveSpeed, rig.velocity.y);
    }

    public void onJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (curJumps > 0)
            {
                jump();
            }
        }

    }

    public void onInteract(InputAction.CallbackContext context)
    {
        Debug.Log("interact");
        if (context.phase == InputActionPhase.Performed)
        {
            if (can_pickup && !holding_box)
            {
                Debug.Log("picking up");
                tryPickup();
                
            }
            else if (holding_box)
            {
                Debug.Log("droping");
                dropBox();
            }
        }

    }
    public void onPunch(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {

        }

    }

    public void tryPickup()
    {
        box.PickUp();
        holding_box = true;
        heldBox = box;
    }
    public void dropBox()
    {
        heldBox.DropBox();
        holding_box = false;
    }

    private void jump()
    {
        rig.velocity = new Vector2(rig.velocity.x, 0);
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        curJumps--;
    }

    public void onMoveInput(InputAction.CallbackContext context)
    {
        curMoveInput = context.ReadValue<float>();
    }
}
