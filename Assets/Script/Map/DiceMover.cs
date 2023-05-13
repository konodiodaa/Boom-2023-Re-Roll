using System;
using UnityEngine;

namespace Script.Map{
    public class DiceMover: MonoBehaviour{
        public Dice dice;
        public ClickDetector detector;

        public Transform arrow;
        public PowerBar powBar;

        public float arrowSpinSpd = 1;
        public float powBarChangeSpd = 1;
        public float powAmplifier = 40;

        public Vector2 curDir = Vector2.zero;
        public float curPower = 0;
        public int curPowerSign = 1;


        public enum State{
            Idle,
            ChooseDir,
            ChoosePower,
        }

        public State curState = State.Idle;

        private void Start(){
            detector.PointerClick += OnClick;
        }

        private void Update(){
            switch (curState){
                case State.Idle:
                    break;
                case State.ChooseDir:
                    arrow.Rotate(0, 0, arrowSpinSpd * Time.deltaTime);
                    break;
                case State.ChoosePower:
                    curPower += curPowerSign * powBarChangeSpd * Time.deltaTime;
                    if (curPower > 1){
                        curPowerSign = -1;
                        curPower = 1;
                    } else if (curPower < 0){
                        curPowerSign = 1;
                        curPower = 0;
                    }
                    powBar.SetPercentage(curPower);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void StartChooseDir(){
            arrow.rotation = Quaternion.Euler(0, 0, 0);
            curDir = Vector2.right;
            arrow.gameObject.SetActive(true);
            var mouse = Input.mousePosition;
            mouse = Camera.current.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 0));
            mouse.z = arrow.position.z;
            arrow.position = mouse;
        }

        private void StartChoosePower(){
            curPower = 0;
            powBar.gameObject.SetActive(true);
        }

        private void EndChooseDir(){
        }

        private void EndChoosePower(){
            var z = arrow.rotation.z;
            curDir = new Vector2(Mathf.Cos(z), Mathf.Sin(z));
            Debug.Log($"curDir: {curDir.ToString()}");
            arrow.gameObject.SetActive(false);
            powBar.gameObject.SetActive(false);
            Debug.Log($"curPow: {curPower}");
        }

        private void OnClick(){
            switch (curState){
                case State.Idle:
                    curState = State.ChooseDir;
                    StartChooseDir();
                    break;
                case State.ChooseDir:
                    EndChooseDir();
                    curState = State.ChoosePower;
                    StartChoosePower();
                    break;
                case State.ChoosePower:
                    EndChoosePower();
                    curState = State.Idle;
                    dice.Move(curDir, curPower * powAmplifier);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}