using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBase : MonoBehaviour
{
    [SerializeField]
    private EventDefine ed;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(EventHandle);
    }

    private void EventHandle()
    {
        EventCenter.Broadcast(ed);
    }
}
