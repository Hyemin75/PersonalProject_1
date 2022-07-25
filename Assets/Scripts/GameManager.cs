using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector2 formerPos = new Vector2(-0.7f, -2.84f);
    Vector2 leftPos = new Vector2(-0.73f, 0.4f), 
            rightPos = new Vector2(0.73f, 0.4f);

    public GameObject[] stairs;

    enum State {start, spawnLeft, spawnRight, leftDir, rightDir };
    State state = State.start;

    private int direction = 0;

    private void Awake()
    {
        SpawnStair();
    }

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
            
            if(i != 0)
            {
                direction = Random.Range(0,9);
                
                if(direction <= 2)
                {
                    if (state == State.spawnLeft)
                    {
                        state = State.rightDir;
                    }
                }
                else if(direction >= 7)
                {
                    if (state == State.spawnRight)
                    {
                        state = State.leftDir;
                    }
                }
            }
        }
    }
}
