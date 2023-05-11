using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Test : MonoBehaviour
{
    private int STR;
    private int DEX;
    private int INT;
    private int FatePoint;

    private static GameManager_Test _instance;

    private void Awake()
    {
        STR = 1;
        DEX = 2;
        INT = 3;
        FatePoint = 4;

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager_Test Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager_Test>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameManager_Test>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    public int GetSTR()
    {
        return STR;
    }

    public int GetDEX()
    {
        return DEX;
    }

    public int GetINT()
    {
        return INT;
    }
    public int GetFP()
    {
        return FatePoint;
    }

    // test function
    public void IncrementTest()
    {
        STR++;
        DEX++;
        INT++;
        EventCenter.Broadcast(EventDefine.updateAttrText); // call attribute panel to update data view
    }
}
