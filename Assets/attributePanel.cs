using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class attributePanel : MonoBehaviour
{
    // data for ui view
    private TextMeshProUGUI text_STR;
    private TextMeshProUGUI text_DEX;
    private TextMeshProUGUI text_INT;
    private TextMeshProUGUI text_FatePoint;

    private void Awake()
    {
        text_STR = transform.Find("attr").Find("STR").GetComponent<TextMeshProUGUI>();
        text_DEX = transform.Find("attr").Find("DEX").GetComponent<TextMeshProUGUI>();
        text_INT = transform.Find("attr").Find("INT").GetComponent<TextMeshProUGUI>();
        text_FatePoint = transform.Find("fate").Find("FatePoint").GetComponent<TextMeshProUGUI>();


        EventCenter.AddListener(EventDefine.updateAttrText, updateAttrText); // register update attribute data event.
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.updateAttrText, updateAttrText);
    }

    private void Start()
    {
        updateAttrText();
    }

    // update the attribute data in ui view.
    private void updateAttrText()
    {
        text_STR.text = GameManager_Test.Instance.GetSTR().ToString();
        text_DEX.text = GameManager_Test.Instance.GetDEX().ToString();
        text_INT.text = GameManager_Test.Instance.GetINT().ToString();
        text_FatePoint.text = GameManager_Test.Instance.GetFP().ToString();
    }

    private void AddAttribute()
    {
        GameManager_Test.Instance.IncrementTest();
    }
}
