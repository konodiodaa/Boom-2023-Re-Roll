using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

namespace Script.Map{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Dice: MonoBehaviour{
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _collider2D;

        public MapManager map;
 
        public float velThreshold = 0.1f;
        public float distanceThreshold = 0.1f;

        public bool isMoving = false;

        private int _curMovingTime = 0;
        private Coroutine _routine = null;

        public float snapLineSpd = 1;
        public float snapRotSpd = 1;

        public bool isSnapping = false;

        private void Start(){
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider2D = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate(){

            if (isSnapping){
                    
                var curRot = _rigidbody2D.rotation;
                while (curRot < -180) curRot += 360;
                while (curRot > 180) curRot -= 360;
                
                var cardPos = GetNearestCardPosition();
                var dis = (cardPos - _rigidbody2D.position).magnitude;
                if (dis > distanceThreshold)
                {
                    var position = _rigidbody2D.position;
                    var velDir = (cardPos - position).normalized;
                    var oriVel = _rigidbody2D.velocity.magnitude;
                    var vel = oriVel * snapLineSpd * Time.fixedDeltaTime;
                    vel = Mathf.Min(dis, vel);
                    _rigidbody2D.MovePosition(_rigidbody2D.position + velDir * vel);

                }

                if (Mathf.Abs(_rigidbody2D.rotation) > float.Epsilon * 100){
                    var curRotSpd = snapRotSpd * Time.fixedDeltaTime;
                    if (curRotSpd > Mathf.Abs(_rigidbody2D.rotation)){
                        curRotSpd = -_rigidbody2D.rotation;
                    } else{
                        curRotSpd *= -Mathf.Sign(curRot);
                    }
                    _rigidbody2D.SetRotation(curRot + curRotSpd );
                }

                if (dis < distanceThreshold && Mathf.Abs(_rigidbody2D.rotation) < float.Epsilon* 100){
                    isSnapping = false;
                    isMoving = false;
                    _rigidbody2D.velocity = Vector2.zero;
                    _rigidbody2D.angularVelocity = 0;
                    EventCenter.Broadcast(EventDefine.openEventPanel);
                }
            }
                
            if (!isMoving) return;
            _curMovingTime += 1;
            if (_curMovingTime < 3) return;
            if ((_rigidbody2D.velocity.magnitude < velThreshold) && _routine == null){
                isSnapping = true;
            }

        }

        private Vector2 GetNearestCardPosition(){
            var curMin = float.MaxValue;
            var ret = Vector2.zero;
            foreach (var card in map.cards){
                var pos = card.transform.position;
                var pos2 = new Vector2(pos.x, pos.y);
                var curDis = (pos2 - _rigidbody2D.position).magnitude;
                if (curDis < curMin){
                    curMin = curDis;
                    ret = pos2;
                }
            }

            return ret;
        }

        public void Move(Vector2 direction, float pow){
            isMoving = true;
            _rigidbody2D.freezeRotation = false;
            _curMovingTime = 0;
            direction = direction.normalized * pow;
            // _rigidbody2D.AddForce(direction);
            var size = _collider2D.size * 0.3f;
            var x = Random.Range(-size.x, size.x);
            var y = Random.Range(-size.y, size.y);
            _rigidbody2D.AddForceAtPosition(direction, new Vector2(x, y));
        }        
    }
}