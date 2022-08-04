using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip death;
    private AudioSource audioSource;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;

    private float turn = 0f;

    private class AnimID
    {
        public static readonly int IsMove = Animator.StringToHash("Move");
        public static readonly int DIE = Animator.StringToHash("Die");
    }


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Resetting()
    {
        rigidbody2d.gravityScale = 0f;
        transform.position = new Vector2(0, -0.78f);
        
    }

    public void Climb()
    {
        animator.SetTrigger(AnimID.IsMove);
        audioSource.Play();
    }

    public void TurnRight()
    {
        spriteRenderer.flipX = true;
        audioSource.Play();
        animator.SetTrigger(AnimID.IsMove);
    }

    public void TurnLeft()
    {
        spriteRenderer.flipX = false;
        audioSource.Play();
        animator.SetTrigger(AnimID.IsMove);
    }

    public void Die()
    {
        animator.SetTrigger(AnimID.DIE);
        audioSource.PlayOneShot(death);

        rigidbody2d.gravityScale = 1f;
    }


}