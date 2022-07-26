using UnityEngine;

// 게임 오브젝트를 키입력마다 움직이는 스크립트
public class BackGroundMove : MonoBehaviour
{
    public float movementDegree = 0.01f;

    private int direction = -1; // x축 왼쪽/오른쪽 평행이동 방향 결정

    private void Update()
    {
        //플레이어의 현재 방향을 받아 키 입력 받았을 때 이동
        if (!GameManager.Instance.isGameOver && Input.GetKey(KeyCode.Z))
        {
            transform.Translate( 0f, -1 * movementDegree, 0f);
        }
    }

}
