using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    //방향을 결정하는 변수
    private int directionProbability = 0;
    
    Vector2 formerPos = new Vector2(-0.7f, -2.84f);
    Vector2 leftPos = new Vector2(-0.73f, 0.4f),
            rightPos = new Vector2(0.73f, 0.4f);

    //계단 상태
    enum State { start, spawnLeft, spawnRight, leftDir, rightDir };
    State state = State.start;

    public GameObject[] stairs;
    private int stairsCountNum = 0;

    // 처음 실행했을 때 생성되는 계단들 생성
    private void Awake()
    {
        SpawnStair();
    }

    //계단 생성
    private void SpawnStair()
    {
        for (int i = 0; i < stairs.Length; i++)
        {
            switch (state)
            {
                case State.start:
                    stairs[i].transform.position = formerPos;
                    state = State.spawnLeft;
                    break;
                case State.spawnLeft:
                    stairs[i].transform.position = formerPos + leftPos;
                    break;
                case State.spawnRight:
                    stairs[i].transform.position = formerPos + rightPos;
                    break;
                case State.rightDir:
                    stairs[i].transform.position = formerPos + rightPos;
                    state = State.spawnRight;
                    break;
                case State.leftDir:
                    stairs[i].transform.position = formerPos + leftPos;
                    state = State.spawnLeft;
                    break;
            }

            formerPos = stairs[i].transform.position;

            if (i != 0)
            {
                directionProbability = Random.Range(0, 9);

                if (directionProbability <= 2)
                {
                    if (state == State.spawnLeft)
                    {
                        state = State.rightDir;
                    }
                }
                else if (directionProbability >= 7)
                {
                    if (state == State.spawnRight)
                    {
                        state = State.leftDir;
                    }
                }
            }
        }
    }

    private void Update()
    {
        StairMovement();
    }


    private void SpawnStair(int stairNum)
    {

    }

    private void StairMovement()
    {
        //Vector2 Downright = new Vector2(0.73f, -0.4f);
        //Vector2 DownLeft = new Vector2(-0.73f, -0.4f);
        //
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    if (state == State.spawnLeft)
        //    {
        //        for (int i = 0; i < stairs.Length; ++i)
        //        {
        //            stairs[i].transform.position = formerPos + Downright;
        //        }
        //    }
        //    else if (state == State.spawnRight)
        //    {
        //        for (int k = 0; k < stairs.Length; ++k)
        //        {
        //            stairs[k].transform.position = formerPos + DownLeft;
        //        }
        //    }
        //
        //    
        //}
    }
}
