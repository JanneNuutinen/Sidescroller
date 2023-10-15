using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //For this gameobject's rigidbody component used later in update()
    private Rigidbody rb = null;

    private Animator playerAnim;

    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

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

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround && !gameOver)
        {
            //Add an impulse force upwards
            rb.AddForce(Vector3.up*JumpForce,ForceMode.Impulse);

            //We are not on ground anymore
            IsOnGround = false;

            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log ("Game Over");

            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            //Time.timeScale = 0
        }
    }
}
