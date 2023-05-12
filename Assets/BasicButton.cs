using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicButton : MonoBehaviour
{
    [SerializeField]
    private EventDefine btnEvent;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(BTNClicked);
    }

    private void BTNClicked()
    {
        EventCenter.Broadcast(btnEvent);
    }
}
