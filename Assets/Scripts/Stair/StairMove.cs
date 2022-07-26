using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StairMove : MonoBehaviour
{
    private Vector3 vector;
    public float hight = -0.38f;
    public float leftDir = 0.73f;
    public float rightDir = -0.73f;


    public void StairMoveDown()
    {
        vector = transform.position;
        transform.Translate(leftDir, hight, 0);
    }



}
