using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EventPanel;

    private void Awake()
    {
        EventPanel.SetActive(false);

        EventCenter.AddListener(EventDefine.openEventPanel,openEventPanel);
        EventCenter.AddListener(EventDefine.closeEventPanel_Continue, ContinueHandle);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.openEventPanel, openEventPanel);
        EventCenter.RemoveListener(EventDefine.closeEventPanel_Continue, ContinueHandle);
    }

    private void openEventPanel()
    {
        EventPanel.SetActive(true);
    }

    private void ContinueHandle()
    {
        EventPanel.SetActive(false);
    }
}
