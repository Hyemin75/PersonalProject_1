using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip death;
    private AudioSource audioSource;
    private Animator animator;

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

    }

    public void Climb()
    {
        animator.SetTrigger(AnimID.IsMove);
        audioSource.Play();
    }

    public void Turn()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, turn, 0));
        turn += turn;
        audioSource.Play();
        animator.SetTrigger(AnimID.IsMove);
    }

    public void Die()
    {
        animator.SetTrigger(AnimID.DIE);
        audioSource.PlayOneShot(death);
    }


}