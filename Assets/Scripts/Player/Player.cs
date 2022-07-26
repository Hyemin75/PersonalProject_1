using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int stairIndex, money;
    
    //플레이어 상태 
    private bool isLeft = true;
    private bool isRight = false;
    
    public Animator animator;
    public GameManager gameManager;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Climb(bool isChange)
    {
        if (isChange)
        {
            if (isLeft == true)
            {
                isLeft = false;
                isRight = true;
            }
            else if(isRight == true)
            {
                isRight = false;
                isLeft = true;
            }
        }
        
        

    }

}