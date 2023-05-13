using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Map{
    public class ClickDetector : MonoBehaviour{
        public event Action PointerClick;
        private void OnMouseUp(){
            Debug.Log("Click");
            PointerClick?.Invoke();
        }
    }
}
