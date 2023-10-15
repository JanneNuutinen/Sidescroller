using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For this gameobject's rigidbody component used later in update()
    private Rigidbody rb = null;

    private Animator playerAnim;

    public float JumpForce = 7.0f;

    //Boolean for tracking if the player is on ground
    public bool IsOnGround = true;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= 2.0f;

        Debug.Log(Physics.gravity);

        rb = GetComponent<Rigidbody>();

        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            //Add an impulse force upwards
            rb.AddForce(Vector3.up*JumpForce,ForceMode.Impulse);

            //We are not on ground anymore
            IsOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");

            gameOver = true;
        }
    }
}
