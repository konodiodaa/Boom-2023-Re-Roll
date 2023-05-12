using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Choice
{
    Attack,
    Threat,
    Defend,
    Dodge,
    Check,
    Talk
}

public class ChoiceButton : MonoBehaviour
{
    [Header("Choice Button Type")]
    public Choice id;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChoiceBTNClicked);
    }

    private void ChoiceBTNClicked()
    {
        EventCenter.Broadcast(EventDefine.ChoiceSelected,id);
    }
}
