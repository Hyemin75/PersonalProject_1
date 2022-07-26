using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip death;
    public AudioClip climbClip;
    public int stairIndex, money;

    private bool isGrounded = true;
    private bool isLeft = true;
    private bool isRight = false;
    private bool isDead = false;
    private Stairs[] _stairs;
    //움직임 xy축

    private Animator animator;
    private AudioSource audioSource;    

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(isDead)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                audioSource.Play();
                animator.SetTrigger("Move");
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        animator.SetBool("Die", isGrounded);
        audioSource.clip = death;
        audioSource.Play();
        isDead = true;
    }

}
