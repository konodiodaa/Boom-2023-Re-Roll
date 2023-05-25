using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum ChoiceBoxType
{
    STR,
    DEX,
    INT
}

public class ChoiceButton_Box : MonoBehaviour
{
    [SerializeField]
    private ChoiceBoxType cb;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChoiceBoxClickedHandle);
    }

    private void ChoiceBoxClickedHandle()
    {
        EventCenter.Broadcast(EventDefine.ChoiceBoxClicked,cb);
    }
}
