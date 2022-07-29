using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float moveDgree = 0.005f;

    public void MoveBackground()
    {
        transform.Translate(0f, moveDgree, 0f);
        moveDgree -= moveDgree;
    }


}

