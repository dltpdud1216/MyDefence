using UnityEngine;
using System.Collections;


namespace MyDefence
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader Fader;

        [SerializeField]
        private string loadToScene = "MainMenu";

        private float titleTimer = 10f;
        private float countdown = 0f;

        private float showTimer = 3f;
        //쑈타임 체크
        private bool isShow = false;

        public GameObject anykeyUI;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            // AnyKey텍스트 3초 지난 후에 나오기 : 3초 지난 후에 Show
            /*[1]
             * Invoke("ShowAnyKey", showTimer);
            Invoke("GotoMainMenu", titleTimer + showTimer);*/  // 

            //[2] 코루틴 함수
            StartCoroutine(TitleProcess());

        }
        private void Update()
        {
            if (isShow == false)
                return;

            /*//10초가 지나면 자동으로 메인메뉴로 이동(키를 누르지 않아도
            countdown += Time.deltaTime;
            if (countdown > titleTimer)
            {
                //타이머 기능
                GotoMainMenu();

                //타이머 초기화
                countdown = 0f;
                return;
            }*/

            //아무키나 누르면 메인메뉴로 이동
            if (Input.anyKeyDown)
            { 
                GotoMainMenu(); 
                
                //현재 진행중인 코루틴 함수 강제 종료
                StopAllCoroutines();
            }
        }
        #endregion

        #region Custom Method
        private void GotoMainMenu()
        {
            Fader.FadeTo(loadToScene);
        }

        private void ShowAnyKey()
        {
            isShow = true;

            anykeyUI.SetActive(true);

        }
        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(showTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(titleTimer);
            GotoMainMenu();
        }

        #endregion
    }
}