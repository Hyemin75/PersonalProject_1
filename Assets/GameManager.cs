using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] stairs;
    private int currentStair;
    private bool[] isStairRight = new bool[20];
    public Text scoreText;
    private int score;
    public GameObject Button;
    private bool isOver;
    public Player player;
    public GameObject background;
    public float moveDgree = 0.01f;

    void Start()
    {
        Restart();
    }

    public void Restart()
    {

        isOver = false;
        Button.SetActive(false);
        currentStair = 1;
        score = 0;
        scoreText.text = "0";
        stairs[0].position = new Vector2(0, -2f);
        
        for (int i = 1; i < stairs.Length; i++)
        {
            isStairRight[i] = Random.Range(0, 2) == 0;
            if (isStairRight[i])
            {
                stairs[i].position = new Vector2(stairs[i - 1].position.x + 0.75f, stairs[i - 1].position.y + 0.4f);
            }
            else
            {
                stairs[i].position = new Vector2(stairs[i - 1].position.x - 0.75f, stairs[i - 1].position.y + 0.4f);
            }
        }
        player.Resetting();

    }

    void Update()
    {
        if (isOver)
        {
            player.Die();
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
     
            player.TurnRight();
            player.Climb();
            Vector3 newPosition = background.transform.position - new Vector3(0, moveDgree);
            background.transform.position = newPosition;
            if (isStairRight[currentStair])
            {
                NextStair();
                score++;
                scoreText.text = "" + score;
            }
            else
            {
                isOver = true;
                Button.SetActive(true);
                player.Die();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player.TurnLeft();
            player.Climb();
            Vector3 newPosition = background.transform.position - new Vector3(0, moveDgree);
            background.transform.position = newPosition;

            if (!isStairRight[currentStair])
            {

                NextStair();
                score++;
                scoreText.text = "" + score;
            }
            else
            {
                isOver = true;
                Button.SetActive(true);
                player.Die();
            }
        }
    }

    void NextStair()
    {
        for (int i = 0; i < stairs.Length; i++)
        {
            if (isStairRight[currentStair])
            {
                stairs[i].position = new Vector2(stairs[i].position.x - 0.75f, stairs[i].position.y - 0.4f);
            }
            else
            {
                stairs[i].position = new Vector2(stairs[i].position.x + 0.75f, stairs[i].position.y - 0.4f);
            }
        }
        for (int i = 0; i < stairs.Length; i++)
        {
            if (stairs[i].position.y < -3.9f)
            {
                isStairRight[i] = Random.Range(0, 2) == 0;
                if (isStairRight[i])
                {
                    if (i == 0)
                    {
                        stairs[i].position = new Vector2(stairs[19].position.x + 0.75f, 3.75f);
                    }
                    else
                    {
                        stairs[i].position = new Vector2(stairs[i - 1].position.x + 0.75f, 3.75f);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        stairs[i].position = new Vector2(stairs[19].position.x - 0.75f, 3.75f);
                    }
                    else
                    {
                        stairs[i].position = new Vector2(stairs[i - 1].position.x - 0.75f, 3.75f);
                    }
                }
            }
        }
        currentStair++;
        if (currentStair >= 20) currentStair = 0;
    }


}
