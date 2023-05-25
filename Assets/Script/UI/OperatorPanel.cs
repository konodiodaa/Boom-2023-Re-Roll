using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperatorPanel : MonoBehaviour
{
    private Button ReRollbtn;
    private Button Continuebtn;

    private void Awake()
    {
        ReRollbtn = transform.Find("ReRollBTN").GetComponent<Button>();
        Continuebtn = transform.Find("ContinueBTN").GetComponent<Button>();
    }
    // Update is called once per frame

    private void Start()
    {
        ReRollbtn.onClick.AddListener(ReRoll);
        Continuebtn.onClick.AddListener(Continue);
    }

    private void ReRoll()
    {
        //TODO: re roll function
        Debug.Log("Re roll here");
    }

    private void Continue()
    {
        //TODO: continue function
        Debug.Log("Continue here");
    }
}
