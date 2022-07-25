using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip death;
    public AudioClip climb;
    public int stairIndex, money;

    private bool isGrounded = true;
    private bool isLeft = true;
    private bool isRight = false;
    private bool isDead = false;
    
    //������ xy��

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
            
        }
    }



    public void MoveStairs()
    {
        
    }



}
