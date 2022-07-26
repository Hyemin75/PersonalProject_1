using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//���� ���� ���� ǥ��, ���� ������ ui�� �����ϴ� ���� �Ŵ���
// ������ �� �ϳ��� ���� �Ŵ����� ����

public class GameManager : SingletonBehaviour<GameManager>
{

    public GameObject gameOverUI;
    public bool isGameOver = false;

    public UnityEvent<int> OnCoinChanged = new UnityEvent<int>();
    public UnityEvent OnGameOver = new UnityEvent();

    private int CoinIncreaseAmount = 10;

    //���� ������ �ִ� ���� 
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

    private int currentCoin = 0; // ���� ����
    private bool isEnd = false;

    private void Update()
    {
        if(isEnd && Input.GetKeyDown(KeyCode.R)) // �ٽ� ���� ���߿� ��ư���� ���� ����
        {
            reset();
            SceneManager.LoadScene(0);
        }
    }

    public void AddScore()
    {
        CurrentCoin += CoinIncreaseAmount;
    }

    // �÷��̾� ĳ���Ͱ� ����� ���� ������ �����ϴ� �޼���
    public void End()
    {
        GameObject gameOverUI = GameObject.Find("GameOverUI"); // find �Լ��� active �Լ��� ã��
        isEnd = true;
        OnGameOver.Invoke();
    }

    private void reset()
    {
        currentCoin = 0;
        isEnd = false;
    }






}




