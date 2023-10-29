using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPosition;

    private float Widht = 0.0f;

    public float speed = 5.0f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get the start position from this game object
        StartPosition = transform.position;

        //Get the widht of the background
        Widht = GetComponent<BoxCollider2D>().size.x;

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerControllerScript.gameOver == false)
        {
            //Move the game object to the left
            transform.position += Vector3.left * 5.0f * Time.deltaTime * speed;

            // If the object has moved to the left more than width/2 from 
            // the start position...
            if (transform.position.x < StartPosition.x - Widht / 2.0f)
                transform.position = StartPosition;
        }
           
    }
}
