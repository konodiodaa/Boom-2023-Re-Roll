using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChoiceType
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
    public ChoiceType ct;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChoiceHandle);
    }

    void ChoiceHandle()
    {
        EventCenter.Broadcast(EventDefine.ChoiceClicked,ct);
    }
}
