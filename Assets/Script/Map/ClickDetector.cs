using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Map{
    public class ClickDetector : MonoBehaviour{
        public event Action PointerClick;

        private bool isClick;

        private void Awake()
        {
            isClick = true;

            EventCenter.AddListener(EventDefine.openEventPanel, DisableClick);
            EventCenter.AddListener(EventDefine.closeEventPanel_Continue, EnableClick);
        }

        private void OnDestroy()
        {
            EventCenter.RemoveListener(EventDefine.openEventPanel, DisableClick);
            EventCenter.RemoveListener(EventDefine.closeEventPanel_Continue, EnableClick);
        }

        private void OnMouseUp(){
            //Debug.Log("Click");
            if (isClick)
            {
                PointerClick?.Invoke();
            }

        }

        private void DisableClick()
        {
            isClick = false;
        }

        private void EnableClick()
        {
            isClick = true;
        }
    }
}
