using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Settings")]
    public int moveSpeed;
    public float jumpForce;
    public int maxJumps;

    [Header("Components")]
    public Rigidbody2D rig;

    // private variables
    private GameObject interactable;
    public MoveBox box;
    public bool holding_box;
    private int curJumps;
    private float curMoveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].point.y < transform.position.y)
        {
            curJumps = maxJumps;
        }

    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(curMoveInput * moveSpeed, rig.velocity.y);
        if (curMoveInput != 0)
        {
            float x = curMoveInput > 0 ? 1 : -1;
            transform.localScale = new Vector3(x, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            box = collision.GetComponent<MoveBox>();
        }
        else if (collision.CompareTag("Interactable"))
        {
            print("Interacable");
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            box = null;
        }
        else if (collision.CompareTag("Interactable"))
        {
            interactable = null;
        }
    }

    public void onInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Action button was pressed");
            if (box)
            {
                if (!holding_box)
                {
                    Debug.Log("Picking up");
                    holding_box = true;
                    box.PickUp();
                }
                else if (holding_box)
                {
                    Debug.Log("Dropping");
                    holding_box = false;
                    box.DropBox();
                }
            }
            else if (interactable)
            {
                if (interactable.GetComponent<Door>())
                {
                    interactable.GetComponent<Door>().interact();
                }
                else if (interactable.GetComponent<FridgeScript>())
                {
                    interactable.GetComponent<FridgeScript>().interact();
                }
            }

        }
    }

    public void onMoveInput(InputAction.CallbackContext context)
    {
        curMoveInput = context.ReadValue<float>();
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
    private void jump()
    {
        rig.velocity = new Vector2(rig.velocity.x, 0);
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        curJumps--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
