using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EventPanel : MonoBehaviour, IPointerClickHandler
{

    private GameObject Choices; 
    private GameObject StoryPanel; // story panel
    private GameObject Options; 
    private GameObject ResultPanel; 

    private TextMeshProUGUI text_Story;
    private TextMeshProUGUI text_Result;

    // option button
    private OptionButton ob1;
    private OptionButton ob2;

    [Header("StoryPanel Move Attr")]
    [SerializeField]
    private float moveDistance = 100f;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoved; // if the panel has been clicked
    private bool isMoving; // if the panel is still moving
    private bool isHide; // if need to hide choice panel


    private void Awake()
    {

        isMoved = false;
        isMoving = false;

        StoryPanel = transform.Find("StoryContent").gameObject;
        text_Story = StoryPanel.transform.Find("StoryText").GetComponent<TextMeshProUGUI>();
        
        Choices = transform.Find("Choices").gameObject;
        Options = transform.Find("Options").gameObject;

        ResultPanel = transform.Find("ResultContent").gameObject;
        text_Result = ResultPanel.transform.Find("ResultText").GetComponent<TextMeshProUGUI>();

        ob1 = Options.transform.Find("Option_A_BTN").GetComponent<OptionButton>();
        ob2 = Options.transform.Find("Option_B_BTN").GetComponent<OptionButton>();

        if (StoryPanel != null)
        targetPosition = StoryPanel.transform.localPosition + new Vector3(0,moveDistance,0);

        EventCenter.AddListener<Choice>(EventDefine.ChoiceSelected,ChoicedSelectedHandler);
        EventCenter.AddListener<Choice>(EventDefine.OptionSelected, OptionSelectedHandler);
        EventCenter.AddListener(EventDefine.ContinueClicked, ContinueClickedHandler);
    }

    private void OnEnable()
    {
        isMoved = false;
        isMoving = false;
        isHide = false;
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

        if(!isMoving && isMoved && !isHide)
        {
            Choices.SetActive(true);
        }
    }

    private void ChoicedSelectedHandler(Choice id)
    {
        ob1.changeID(id);
        ob2.changeID(id);
        isHide = true;
        Choices.SetActive(false);
        Options.SetActive(true);
    }

    private void OptionSelectedHandler(Choice id)
    {
        Options.SetActive(false);
        ResultPanel.SetActive(true);
    }

    private void ContinueClickedHandler()
    {
        ResultPanel.SetActive(false); 
        StoryPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isMoved) return;
        isMoved = true;
        isMoving = true;
    }

    
}
