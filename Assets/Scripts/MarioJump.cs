using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioJump : MonoBehaviour
{
    
    public Animator animator;
    public Rigidbody rb;
    public float jumpForce = 5f;
    public float jumpDelay = 0.25f; 
    private bool isGrounded = true;
    public AudioClip jumpClip;         
    private AudioSource audioSource;

    public GameObject[] fireObjects;
    
    void Start()
    {
    GameOverPanel.SetActive(false);
    GameOverPanel.SetActive(false);
    audioSource = GetComponent<AudioSource>();
    

    }   
    void Update()
    {   
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            StartCoroutine(JumpSequence());
            
            audioSource.PlayOneShot(jumpClip);
            isGrounded = false;
        }
    }


    IEnumerator JumpSequence()
    {
        isGrounded = false;
        
        animator.SetBool("Jump", true);
        animator.SetBool("Idle", false);
        
              
        yield return new WaitForSeconds(jumpDelay);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        FindObjectOfType<GameHUD>().AddJump();
        animator.SetBool("Down", true);
        animator.SetBool("Jump", false);
       
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
            
        if (collision.gameObject.CompareTag("Ground"))
        {
        isGrounded = true;
        
        animator.SetBool("Idle", true);

        
            
    }
    }
    private void OnTriggerEnter(Collider collision)
{
    if (collision.CompareTag("Fire"))
    {
        GameOver();
    }
}

public GameObject GameOverPanel; 

void GameOver()
{
    Time.timeScale = 0f; 
    GameOverPanel.SetActive(true); 
}

}