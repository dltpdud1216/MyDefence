using System.Net.NetworkInformation;
using UnityEngine;

namespace Sample
{
    //MonoBehaviour클래스의 이벤트함수 예제

    public class EventTest : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("[1] Awake 실행");  //1회실행
        }
        private void OnEnable()
        {
            Debug.Log("[7-1] OnEnavle 실행");  // 1회 실행 - 활성화 할때마다
        }
        private void Start()
        {
            Debug.Log("[2] start 실행");  //1회실행
        }
        private void FixedUpdate()  
        {
            Debug.Log("[3] FixedUpdate 실행"); //1초에 50번 호출, 고정
        }
        private void Update()
        {
            Debug.Log("[4] Update 실행"); // 매 프레임마다 호출,1초 60(300,30)번 호출
        }
        private void LateUpdate()
        {
            Debug.Log("[5] LateUpdate 실행"); // Update() 실행 뒤에 바로 따라서 실행
        }
        private void OnDisable()
        {
            Debug.Log("[7-2] OnDisable 실행");  // 1회 실행 - 비 활성화 할때마다
        }
        private void OnDestroy()
        {
            Debug.Log("[6] OnDestroy실행");   //하이라키 창에서 삭제될때(Object Kill 킬) - 1회 실행 (소멸자랑 동일)
        }
    }

}