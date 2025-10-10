using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MyDefence
{
    /// <summary>
    /// 카메라 제어: 이동,줌인,줌아웃
    /// </summary>

public class CameraController : MonoBehaviour
{
        #region Variables
        public float moveSpeed = 10.0f; //카메라 이동 속도
        
        //카메라 위아래 이동 속도
        public float scrollSpeed = 10f;

        //카메라 최소,최대 높이
        public float minPosY = 10f;
        public float maxPosY = 40f;

        //마우스 위치 경계 변수
        public float border = 10f;

        //카메라 이동 제어 체크 변수
        //true : 이동 불가능, false: 이동 가능
        private bool isCannotMove = false;

        #endregion

        #region Unity Event Method
        private void Update()
        {
          

            //esc key를 한 번 누르면 카메라 이동을 못하게 막는다 isCannotMove = true
            //다시 esc key를 누르면 카메라 이동을 다시 가능하게 한다 isCannotMove = false
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Input.GetKeyDown(KeyCode.Escape)");
                if(isCannotMove == false)
                {
                    isCannotMove = true;
                }
                else if (isCannotMove == true)
                {
                    isCannotMove = false;
                }
             
            }
            if (isCannotMove)
                return;

            //w키를 입력하면 앞으로 이동

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate( Vector3.forward * Time.deltaTime * moveSpeed,Space.World);
            }
            //s키를 입력하면 뒤로 이동      
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }
            //a키를 입력하면 왼쪽으로 이동
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            //d키를 입력하면 오른쪽으로 이동
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }
            //마우스를 스크린 상하좌우 끝 부분(기준 폭: 10)에 가져가면 맵을 스크롤 시킨다
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            Debug.Log($"마우스 position{mouseX},{mouseY}");

            //앞으로 이동 - height, height -10
            if (mouseY >= (Screen.height - border) && mouseY<= Screen.height)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseY >= 0f && mouseY <= border)
            {
                this.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
            }

            if (mouseX >= 0f && mouseX <= border)
            {
                this.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            }
            if (mouseX >= (Screen.width - border) && mouseX <= Screen.width)
            {
                this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed, Space.World);
            }

            //마우스 스크롤값을 입력 받아 줌인, 줌아웃(높이조절)기능 구현
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Debug.Log($"Mouse ScrollWheel : {scroll}");

            Vector3 upDownPosition = this.transform.position;
            //y축 이동만 연산 - 보정계수 1000 적용 
            upDownPosition.y += scroll*1000 * Time.deltaTime * scrollSpeed;
            //카메라 최소,최대 높이 제한
            upDownPosition.y = Mathf.Clamp(upDownPosition.y, minPosY, maxPosY);
            this.transform.position = upDownPosition;
        }
    }
        #endregion
    }
