using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Settings")]
    public int moveSpeed;
    public float maxJumpForce;
    public float jumpForce;
    public float reducedJumpForce;
    public int maxJumps;

    [Header("Components")]
    public Rigidbody2D rig;

    // private variables
    [Header("Accessed by other objects")]
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
        else if (collision.gameObject.layer == 6)
        {
            interactable = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            if (!holding_box)
                box = null;
        }
        else if (collision.gameObject.layer == 6)
        {
            interactable = null;
        }
    }

    public void onInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (interactable)
            {
                if (interactable.CompareTag("Door"))
                {
                    interactable.GetComponent<Door>().interact();
                }
                else if (interactable.CompareTag("Fridge"))
                {
                    interactable.GetComponent<FridgeScript>().interact();
                }
                else if (interactable.CompareTag("Microwave"))
                {
                    interactable.GetComponent<Microwave>().interact();
                }
                else if (interactable.CompareTag("Shower"))
                {
                    interactable.GetComponent<Shower>().interact();
                }
                else if (interactable.CompareTag("Toilet"))
                {
                    interactable.GetComponent<Tiolet>().interact();
                }
                else if (interactable.CompareTag("Laundry"))
                {
                    interactable.GetComponent<Laundry>().interact();
                }

            }
            else if (box)
            {
                if (!holding_box)
                {
                    holding_box = true;
                    box.PickUp();
                }
                else if (holding_box)
                {
                    holding_box = false;
                    box.DropBox();
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
