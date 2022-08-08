using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRG;
    private float jumpForce = 700;
    private float gravityModifier = 2;
    private bool isOnGround;

    private Animator PlayerAnim;

    [SerializeField] ParticleSystem dirtParticle, explosionParticle;

    private AudioSource actionSFX;
    [SerializeField] AudioClip jumpSound, crushSound;


    internal static int score = 0;
    internal static bool gameOver = false;

    void Start()
    {
        playerRG = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isOnGround = true;

        PlayerAnim = GetComponent<Animator>();

        actionSFX = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)  
        {
            playerRG.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            PlayerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            actionSFX.PlayOneShot(jumpSound, 1.0f);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver) 
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle") && isOnGround == true)
        {
            gameOver = true;
            dirtParticle.Stop();
            explosionParticle.Play();
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 1);
            actionSFX.PlayOneShot(crushSound, 0.5f);
            Debug.Log("GameOver");
        }
        else if (collision.gameObject.CompareTag("Obstacle") && isOnGround == false)
        {
            gameOver = true;
            dirtParticle.Stop();
            explosionParticle.Play();
            PlayerAnim.SetBool("Death_b", true);
            PlayerAnim.SetInteger("DeathType_int", 2);
            actionSFX.PlayOneShot(crushSound, 0.5f);
            Debug.Log("GameOver");
        }
    }
}
