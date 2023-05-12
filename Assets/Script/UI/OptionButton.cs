using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    private Choice id;

    [SerializeField]
    private TextMeshProUGUI OptionText;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OptionSelected);
    }

    private void OptionSelected()
    {
        EventCenter.Broadcast(EventDefine.OptionSelected,id);
    }

    public void changeID(Choice id)
    {
        this.id = id;
        OptionText.text = id.ToString();
    }
}
