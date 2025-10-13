using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample
{
    /// <summary>
    /// 카메라 제어 : 이동, - 뉴인풋시스템
    /// </summary>
    public class CameraControllerNew : MonoBehaviour
    {
        #region Variables
        //new inputsystem class 객체 선언
        private InputActionsTest inputActions;

        //카메라 이동속도
        public float moveSpeed = 10f;

        //카메라 이동 입력값 저장
        Vector2 inputVector;

        //마우스 위치 경계 변수
        public float border = 10f;
        #endregion

        #region Unity Event Test [2-1] 스크립트를 이용하여 값 가져오기

        private void Awake()
        {
            //참조 : new inputsystem class 객체 생성
            inputActions = new InputActionsTest();
        }
        private void OnEnable()
        {
            //new inputsystem class 객체 활성화
            inputActions.Enable();
            inputActions.Camera.Jump.performed += Jump;
            //inputActions.Camera.Jump.started += Jump;
            //inputActions.Camera.Jump.canceled += Jump;
        }
        private void OnDisable()
        {
            //new inputsystem class 객체 비활성화
            inputActions.Disable();
        }
        private void Update()
        {
            //WASD(Arrow) 입력 값에 따른 카메라 이동 : new inputsystem Class 객체.액션맵이름.액션이름.ReadValue<타입>();
            Vector2 inputVector = inputActions.Camera.Move.ReadValue<Vector2>();
            //inputVector.x : a,d 입력값
            //inputVector.y : w,s 입력값
            //이동 : 방향 * Time.deltaTime * meveSpeed
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);

            //MousePosition 값을 읽어서 카메라 이동 구현
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            float mouseX = mousePosition.x;
            float mouseY = mousePosition.y;

            //앞으로 이동 - height, height -10
            if (mouseY >= (Screen.height - border) && mouseY <= Screen.height)
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
        }

        public void Jump(InputAction.CallbackContext context) //[2-3]과 동일하지만 스크립트로도 사용가능
        {
            //context.started - 버튼을 눌렀을 때
            //context.performed - 버튼을 누르고 있을 때(1번 호출)
            //context.canceled - 버튼에서 손을 땠을 때

            if (context.performed)
            {
                Debug.Log("jump 버튼을 눌렀습니다.");
            }
        }


        /*   //space bar 입력 값에 따른 점프 버튼 처리
           bool isJump = inputActions.Camera.Jump.ReadValue<bool>();
           if (isJump)
           {
               Debug.Log("jump 버튼을 눌렀습니다.");
           }*/

            #endregion

            #region Unity Event Method [2-2] SendMassage 방법
      /*  private void Update()
        {
            //카메라 이동
            Vector3 dir = new Vector3(inputVector.x, 0f, inputVector.y);
            transform.Translate(dir * Time.deltaTime * moveSpeed, Space.World);
        }*/
        #endregion

        #region  [2-2] Custum Method  
     /*   public void OnMove(InputValue value)
        {
           inputVector = value.Get<Vector2>();
        }
        public void OnJump(InputValue value)
        {
           if(value.isPressed)
           {
               Debug.Log("jump 버튼을 눌렀습니다.");
            }
        }*/
        #endregion

        #region [2-3] Unity Event 등록 방법
        public void Move(InputAction.CallbackContext context)
        {
            inputVector = context.ReadValue<Vector2>();

        }

        /*public void Jump(InputAction.CallbackContext context)
        {
            //context.started - 버튼을 눌렀을 때
            //context.performed - 버튼을 누르고 있을 때(1번 호출)
            //context.canceled - 버튼에서 손을 땠을 때

            if (context.performed)
            {
                Debug.Log("jump 버튼을 눌렀습니다.");
            }

        }*/
        #endregion
    }
}
/*
1. Intpu Action Editor 창 셋팅하기
- Action Map 셋팅 (ex: Camera)
- Action 셋팅 (ex: Move,Jump)

2. New Intput System 에서 유저 인풋값 가져오기 - 3가지 방법
2-1) 스크립트를 이용하여 값 가져오기
- Input Actions 셋팅을 Class 파일로 만들어서 처리한다
- 만들어진 Class의 객체를 생성해서 인풋 값 처리

2-2) SendMassage 방법
- 하이라키창 오브젝트에서 Player Input 컴포넌트 추가 : 액션맵 바인딩 - actions 에서 드래그 혹은 파일 선택
- Behavior : SendMassage 셋팅
- 인풋 대응 함수 만들기
: 함수 이름 규칙 : On + 액션이름 (InputValue value)

2-3) Unity Event 등록 방법
- 하이라키창 오브젝트에서 Player Input 컴포넌트 추가 : 액션맵 바인딩 - actions 에서 드래그 혹은 파일 선택
- Behavior : Invoke Unity Event 셋팅
- 인풋 대응 함수 만들기
: 이름 규칙 없음, 매개변수 규칙 없음
public void 함수이름(InputAction.CallbackContext context)
{}
- 만든 함수를 대응되는 이벤트에 등록한다

*/