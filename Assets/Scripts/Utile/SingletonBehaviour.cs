using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour // <>���̿��� int�� ������ Ÿ���� ���� �ȴ�� // where���� t�� ���� ���� ������ ��Ÿ�� ���׸��� ����� ���� �� �� �ִ� ����
    //���׸��� C#���� �����ϴ� �Ϲ�ȭ / Ÿ���� ����ó�� ��밡���ϰ��ϴ� or Ÿ�� ������� �� �� �ֵ��� ���� 
{
    private static T instance;

    //���� ����� ���������μ� Ÿ�� ��� class�̸����� ���� ����(������ ��� new�� ����Ͽ� �ν��Ͻ��� �ҷ��;���)
    // Start is called before the first frame update

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

            return;
        }

        instance = GetComponent<T>();
        //�̱����� ���� ��ȯ�� �� �ı��Ǹ� �ȵ�
        DontDestroyOnLoad(gameObject);
    }


}
