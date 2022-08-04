using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float moveDgree = 0.005f;
    private float positionY;

    private void Start()
    {
        positionY = 15.8f + moveDgree;
    }

    public void MoveBackground()
    {
        transform.Translate(0f, positionY, 0f);
        positionY -=  moveDgree;
    }
    

}

