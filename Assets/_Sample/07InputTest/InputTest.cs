using UnityEngine;
using TMPro;

namespace Sample
{
    /// <summary>
    /// Old Input 테스트
    /// </summary>
}
public class InputTest : MonoBehaviour
{
    #region Variables
    float centerX; //화면 중앙 위치 x좌표
    float centerY; //화면 중앙 위치 y좌표

    public TextMeshProUGUI positionText;
    #endregion

    #region Unity Event Method
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //스크린의 크기
        Debug.Log($"Screen width : {Screen.width}, Screen.height : {Screen.height}");
        centerX = Screen.width / 2;
        centerY = Screen.height / 2;
        Debug.Log($"Screen center : {centerX}, {centerY}");
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey
      /*  if(Input.GetKey("w")) //프레임별로 출력
        {
            Debug.Log("W키를 누르고 있습니다");
        }
        if(Input.GetKeyDown(KeyCode.W)) 
        {
            Debug.Log("W키를 눌렀습니다");
        }
        if(Input.GetKeyUp(KeyCode.W)) //눌렀다 떼었을때만 출력
        {
            Debug.Log("W키를 눌렀다가 떼었습니다");
        }*/
        //GetButton - Input Manager에 정의된 Axis(버튼) 이름을 가져와서 사용한다
      
        //if (Input.GetButton("Horizontal")) 
        {
            //a,left : -1 ~ 0
            //d,right : 0 ~ 1
            //입력이 없으면 : 0
            /*float hValue = Input.GetAxis("Horizontal");
            Debug.Log($"Horizontal GetAxis : {hValue}");*/

            //a,left : -1
            //d,right: 1
            //입력이 없으면 : 0
            float hValue = Input.GetAxisRaw("Horizontal");
            Debug.Log($"Horizontal GetAxisRaw : {hValue}");
        }
        //if(Input.GetButton("Vertical"))
        {
            //s,down : -1 ~ 0
            //w,up : 0 ~ 1
            //입력이 없으면 : 0
            /*float vValue = Input.GetAxis("Vertical");
            Debug.Log($"Vertical GetAxis : {vValue}");*/

            //s,down : -1
            //w,up : 1
            //입력이 없으면 : 0
            float vValue = Input.GetAxisRaw("Vertical");
            Debug.Log($"Vertical GetAxisRaw : {vValue}");
        }
       
        //스크린상에서 마우스 위치값 가져오기
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        //Debug.Log($"Mouse Position : {mouseX}, {mouseY}");

        positionText.text = $"Mouse Position : {(int)mouseX}, {(int)mouseY}";
        positionText.rectTransform.position = new Vector2(mouseX, mouseY);
    }
    #endregion
}
