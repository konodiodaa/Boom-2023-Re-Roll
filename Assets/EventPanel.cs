using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EventPanel : MonoBehaviour, IPointerClickHandler
{
    private Button ShowChoiceBTN;

    private GameObject Choices;

    private GameObject StoryPanel;

    [SerializeField]
    private GameObject ResultPanel;
    [SerializeField]
    private GameObject Choice_EX;

    private TextMeshProUGUI text_Story;

    [Header("StoryPanel Move Attr")]
    [SerializeField]
    private float moveDistance = 100f;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 targetPosition;
    [SerializeField]
    private Vector3 originPosition;
    private bool isMoved; // if the panel has been clicked
    private bool isMoving; // if the panel is still moving
    private bool isOpenResult;


    private void Awake()
    {

        isMoved = false;
        isMoving = false;

        StoryPanel = transform.Find("StoryContent").gameObject;
        text_Story = transform.Find("StoryContent").Find("StoryText").GetComponent<TextMeshProUGUI>();
        Choices = transform.Find("Choices").gameObject;

        if (StoryPanel != null)
        targetPosition = StoryPanel.transform.localPosition + new Vector3(0,moveDistance,0);

        EventCenter.AddListener<ChoiceType>(EventDefine.ChoiceClicked, ChoiceHandle);
        EventCenter.AddListener<ChoiceBoxType>(EventDefine.ChoiceBoxClicked, ChoiceBoxHandle);
    }

    private void OnEnable()
    {
        isMoved = false;
        isMoving = false;
        isOpenResult = false;
    }

    private void OnDisable()
    {
        isMoved = false;
        isMoving = false;
        isOpenResult = false;
        StoryPanel.SetActive(true);
        StoryPanel.transform.localPosition = originPosition;
        Choices.SetActive(false);
        ResultPanel.SetActive(false);
    }

    private void Update()
    {
        if(isMoving)
        {
            if (Vector3.Distance(StoryPanel.transform.localPosition, targetPosition) > 1.0f)
                StoryPanel.transform.localPosition = Vector3.Lerp(StoryPanel.transform.localPosition, targetPosition, Time.deltaTime * moveSpeed);
            else
                isMoving = false;
        }

        if(!isMoving && isMoved && !isOpenResult)
        {
            Choices.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isMoved) return;
        isMoved = true;
        isMoving = true;
    }

    private void ChoiceHandle(ChoiceType ct)
    {
        Choice_EX.SetActive(false);
        ResultPanel.SetActive(true);
    }

    private void ChoiceBoxHandle(ChoiceBoxType cb)
    {
        isOpenResult = true;
        Choices.SetActive(false);


        Choice_EX ce = Choice_EX.GetComponent<Choice_EX>();

        switch (cb)
        {
            case ChoiceBoxType.STR:
                ce.A.ct = ChoiceType.Attack;
                ce.B.ct = ChoiceType.Threat;
                ce.A_text.text = "Attack";
                ce.B_text.text = "Threat";
                ce.A_Dec.text = "ssss";
                ce.A_Dec.text = "ddddd";
                break;
            case ChoiceBoxType.DEX:
                ce.A.ct = ChoiceType.Defend;
                ce.B.ct = ChoiceType.Dodge;
                ce.A_text.text = "Defend";
                ce.B_text.text = "Dodge";
                ce.A_Dec.text = "aaaa";
                ce.A_Dec.text = "bbbbb";
                break;
            case ChoiceBoxType.INT:
                ce.A.ct = ChoiceType.Check;
                ce.B.ct = ChoiceType.Talk;
                ce.A_text.text = "Check";
                ce.B_text.text = "Talk";
                ce.A_Dec.text = "rrr";
                ce.A_Dec.text = "www";
                break;
        }

        Choice_EX.SetActive(true);
    }

}
