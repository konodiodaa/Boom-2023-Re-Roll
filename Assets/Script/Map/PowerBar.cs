using System;
using UnityEngine;

namespace Script.Map{
    public class PowerBar: MonoBehaviour{
        public LineRenderer line;
        public Transform startPos;
        public Transform endPos;

        private void Start(){
            line.useWorldSpace = true;
            var position = startPos.position;
            line.SetPositions(new []{
                position,
                position
            });
        }

        public void SetPercentage(float p){
            p = Math.Clamp(p, 0, 1);
            var end = endPos.position;
            var start = startPos.position;
            var cur = Vector3.Lerp(start, end, p);
            line.SetPosition(1, cur);
        }
    }
}