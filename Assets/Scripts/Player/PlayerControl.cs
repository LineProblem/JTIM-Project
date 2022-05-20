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
    private Vector2 spawnPos;

    [Header("Components")]
    public Rigidbody2D rig;
    public Animator anim;
    public AudioSource jumpSnd;
    public SpriteRenderer backpack;

    // private variables
    [Header("Accessed by other objects")]
    public int money;
    private GameObject interactable;
    public MoveBox box;
    private Trash trash;
    public bool holding_box;
    private int curJumps;
    public float curMoveInput;
    public bool moving;
    public bool jumping;
    public bool hasKey;
    private GameControl gameControl;



    // Start is called before the first frame update
    void Start()
    {

        spawnPos = transform.position;
        gameControl = FindObjectOfType<GameControl>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if the collision is the ground and below the player.
        // allows for side clipping while jumping
        if (collision.contacts[0].point.y < transform.position.y)
        {
            curJumps = maxJumps;
        }
    }

    bool IsOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(0, 0.2f, 0), Vector2.down);
        return hit.collider != null;
    }

    private void FixedUpdate()
    {
        if (holding_box)
        {
            box = GetComponentInChildren<MoveBox>();
        }
        rig.velocity = new Vector2(curMoveInput * moveSpeed, rig.velocity.y);

        if (curMoveInput != 0 && !jumping)
        {
            moving = true;
            anim.SetBool("Walking", true);
            float x = curMoveInput > 0 ? 1 : -1;
            transform.localScale = new Vector3(x, 1, 1);
        }
        else
        {
            moving = false;
            anim.SetBool("Walking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            box = collision.GetComponent<MoveBox>();
        }
        else if (collision.CompareTag("Trash"))
        {
            trash = collision.GetComponent<Trash>();
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
        else if (collision.CompareTag("Trash"))
        {
            trash = null;
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
            if (holding_box == false && box)
            {
                if (box)
                {
                    holding_box = true;
                    box.PickUp();
                }

            }
            else if (interactable)
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
                else if (interactable.CompareTag("Hamper"))
                {
                    interactable.GetComponent<Hamper>().interact();
                }
                else if (interactable.CompareTag("tv"))
                {
                    interactable.GetComponent<TVScript>().interact();
                }
                else if (interactable.CompareTag("coin"))
                {
                    interactable.GetComponent<Coin>().interact();
                }
                else if (interactable.CompareTag("arcade"))
                {
                    interactable.GetComponent<arcadeScript>().interact();
                }
                else if (interactable.CompareTag("locker"))
                {
                    interactable.GetComponent<lockerScript>().interact();
                }
                else if (interactable.CompareTag("vending"))
                {
                    interactable.GetComponent<vendingScript>().interact();
                }
                else if (interactable.CompareTag("desk"))
                {
                    interactable.GetComponent<DeskScript>().interact();
                }
                else if (interactable.CompareTag("door sound"))
                {
                    interactable.GetComponent<DoorSound>().interact();
                }

                else if (interactable.CompareTag("backpack"))
                {
                    Destroy(interactable);
                    interactable = null;
                    backpack.enabled = true;
                    gameControl.objectives.Remove("Find backpack in locker");
                }
                else if (interactable.CompareTag("key"))
                {
                    hasKey = true;
                    Destroy(interactable);
                    interactable = null;
                }
                else if (interactable.CompareTag("Goal"))
                {
                    if (interactable.GetComponent<DoorLevelOne>())
                    {
                        interactable.GetComponent<DoorLevelOne>().interact();
                    }
                    if (interactable.GetComponent<ClassDoor>())
                    {
                        interactable.GetComponent<ClassDoor>().interact();
                    }
                }

            }
            else if (trash)
            {
                if (!holding_box)
                {
                    holding_box = true;
                    trash.PickUp();
                }
                else if (holding_box)
                {
                    holding_box = false;
                    trash.DropBox();
                }
            }
            else if (holding_box && box)
            {
                if (box)
                {
                    holding_box = false;
                    box.DropBox();
                }
            }



        }
    }

    public void die()
    {
        transform.position = spawnPos;
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
                jumpSnd.Play();
                jumping = true;
                anim.Play("Jumping");
                anim.SetBool("Jumping", true);
                jump();
            }

        }
        else
        {
            jumping = false;
            anim.SetBool("Jumping", false);
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
        print(IsOnGround());
    }
}
