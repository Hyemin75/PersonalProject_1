using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public int characterIndex, stairIndex, money;


    private bool isGrounded = true;
    private bool isLeft = true;
    private bool isRight = false;
    private bool isDead = false;


    
    //움직임 xy축

    private Rigidbody2D rigidbody;
    private Animator animator;
    private AudioSource audioSource;

    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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

            }
        }
    }



    public void move(bool direction)
    {
        if(direction)
        {
            isLeft = !isLeft;
            
        }
    }



}
