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

    private TextMeshProUGUI text_Story;

    [Header("StoryPanel Move Attr")]
    [SerializeField]
    private float moveDistance = 100f;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoved; // if the panel has been clicked
    private bool isMoving; // if the panel is still moving


    private void Awake()
    {

        isMoved = false;
        isMoving = false;

        StoryPanel = transform.Find("StoryContent").gameObject;
        text_Story = transform.Find("StoryContent").Find("StoryText").GetComponent<TextMeshProUGUI>();
        Choices = transform.Find("Choices").gameObject;

        if (StoryPanel != null)
        targetPosition = StoryPanel.transform.localPosition + new Vector3(0,moveDistance,0);
    }

    private void OnEnable()
    {
        isMoved = false;
        isMoving = false;
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

        if(!isMoving && isMoved)
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
}
