using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For this gameobject's rigidbody component used later in update()
    private Rigidbody rb = null;

    public float JumpForce = 7.0f;

    //Boolean for tracking if the player is on ground
    public bool IsOnGround = true;

    private void OnCollisionEnter(Collision collision)
    {
        //The other collider has to be the ground
        IsOnGround = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= 2.0f;

        Debug.Log(Physics.gravity);

        rb = GetComponent<Rigidbody>();
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
        }
    }
}
