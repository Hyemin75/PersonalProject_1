using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Slider hp;
    public TextMeshPro score;

    private float damage = 0.01f;
    private float time = 0.0f;

    private void Awake()
    {
        hp.maxValue = 100f;
    }

    public bool DecreaseHp()
    {
        if(hp.value <= 0)
        {
            return false;
        }

        if((time += Time.deltaTime) > 1 && damage < 20.0f)
        {
            time = 0.0f;
            damage += 0.01f;
        }

        hp.value -= damage;
        return true;
    }

    public void IncreaseHp()
    {
        hp.value += 20.0f;
    }

    public void UpdateScore(int score)
    {
        this.score.text = score.ToString(); 
    }
}
