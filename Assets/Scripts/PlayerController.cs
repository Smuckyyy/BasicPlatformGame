using UnityEngine;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    private float inputHorizontal;
    //Because this is public, we have access to it in the unity editor.
    //Do not put a speed and have it = to anything, we will do that in Unity editor
    public float horizontalMoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //I can only get this component because the rigidbody2d is attached to the player
        //This script is also attached to the player
        rb = GetComponent<Rigidbody2D>();

        //Debug.Log("Hello from Player Controller!");
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        //jump();
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

        rb.linearVelocity = new Vector2(horizontalMoveSpeed * inputHorizontal, rb.linearVelocity.y);

    }
}
