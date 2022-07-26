using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//게임 오버 상태 표현, 게임 점수와 ui를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재

public class GameManager : SingletonBehaviour<GameManager>
{

    public GameObject gameOverUI;
    public bool isGameOver = false;

    public UnityEvent<int> OnCoinChanged = new UnityEvent<int>();
    public UnityEvent OnGameOver = new UnityEvent();

    private int CoinIncreaseAmount = 10;

    //현재 가지고 있는 코인 
    public int CurrentCoin
    {
        get
        {
            return currentCoin;
        }
        set
        {
            currentCoin = value;
            OnCoinChanged.Invoke(currentCoin);
        }
    }

    private int currentCoin = 0; // 게임 점수
    private bool isEnd = false;

    private void Update()
    {
        if(isEnd && Input.GetKeyDown(KeyCode.R)) // 다시 시작 나중에 버튼으로 수정 예정
        {
            reset();
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore()
    {
        CurrentCoin += CoinIncreaseAmount;
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void End()
    {
        GameObject gameOverUI = GameObject.Find("GameOverUI"); // find 함수는 active 함수만 찾음
        isEnd = true;
        OnGameOver.Invoke();
    }

    private void reset()
    {
        currentCoin = 0;
        isEnd = false;
    }






}




