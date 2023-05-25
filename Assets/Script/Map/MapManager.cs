using UnityEngine;

namespace Script.Map{
    public class MapManager : MonoBehaviour{
        public Card[] cards;
        // Start is called before the first frame update
        private void Start(){
            cards = GetComponentsInChildren<Card>();
        }
    }
}
