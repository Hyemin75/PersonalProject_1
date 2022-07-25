using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour // <>사이에는 int나 원래의 타입은 쓰면 안댄다 // where절은 t에 대한 제한 조건을 나타냄 제네릭을 사용할 때만 쓸 수 있는 문법
    //제네릭은 C#에서 지원하는 일반화 / 타입을 인자처럼 사용가능하게하는 or 타입 상관없이 쓸 수 있도록 만듬 
{
    private static T instance;

    //정적 멤버로 선언함으로서 타입 대신 class이름으로 접근 가능(동적일 경우 new를 사용하여 인스턴스를 불러와야함)
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
        //싱글톤은 씬을 전환할 때 파괴되면 안됨
        DontDestroyOnLoad(gameObject);
    }


}
