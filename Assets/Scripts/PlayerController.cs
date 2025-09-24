using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    private int maxNumJumps;
    private int numJumps;
    //Because this is public, we have access to it in the unity editor.
    //Do not put a speed and have it = to anything, we will do that in Unity editor
    public float horizontalMoveSpeed;
    //We dont look for equality in Unity because of frame rates, always looking for greater than for things like moving.
    //Ex. (If I get to space 4 -> do this. Instead, If I get anything greater than space 4 -> do this)
    public float jumpForce;

    public GameObject doubleJumpHatLocation;
    public GameObject debuffHatLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //I can only get this component because the rigidbody2d is attached to the player
        //This script is also attached to the player
        rb = GetComponent<Rigidbody2D>();
        maxNumJumps = 1;
        numJumps = 1;

        Debug.Log("Hello from Player Controller!");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        jump();
    }

    private void movePlayerLateral()
    {
        //if A/D/<-/-> are pressed, move the player accordingly
        //"Horizontal" is defined in the input section of the project settings
        //The line below will return:
        //0 - no button pressed
        //1 - right arrow or D pressed
        //2 - left arrow or A pressed
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        flipPlayerSprite(inputHorizontal);
        rb.linearVelocity = new UnityEngine.Vector2(horizontalMoveSpeed * inputHorizontal, rb.linearVelocity.y);

    }

    private void flipPlayerSprite(float inputHorizontal)
    {
        //This will flip the sprite based on the direction the player is moving
        //We are using vector3 because unity is "always" in 3D
        if (inputHorizontal > 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.eulerAngles = new UnityEngine.Vector3(0, 180, 0);
        }
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps <= maxNumJumps)
        {
            rb.linearVelocity = new UnityEngine.Vector2(rb.linearVelocity.x, jumpForce);
            numJumps++;
        }
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision will contain information about the object that the player collided with
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Ground"))
        {
            numJumps = 1;
        }
        else if (collision.gameObject.CompareTag("obBottom"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Double Jump
        if (collision.gameObject.CompareTag("PinkCollectable"))
        {
            GameObject hat = collision.gameObject;
            equipDoubleJumpHat(hat);
            maxNumJumps = 2;
        }
        // Debuff
        else if (collision.gameObject.CompareTag("YellowCollectable"))
        {
            GameObject debuffHat = collision.gameObject;
            equipDebuffHat(debuffHat);
        }
    
    }

    private void equipDoubleJumpHat(GameObject hat)
    {
        //collision.gameObject.transform.SetParent(null);
        hat.transform.position = doubleJumpHatLocation.transform.position;
        hat.transform.SetParent(this.gameObject.transform);
    }

    private void equipDebuffHat(GameObject debuffHat)
    {
        //collision.gameObject.transform.SetParent(null);
        debuffHat.transform.position = debuffHatLocation.transform.position;
        debuffHat.transform.SetParent(this.gameObject.transform);
    }
}
