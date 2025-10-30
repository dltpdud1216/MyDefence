using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class Paused : MonoBehaviour
    {
        /// <summary>
        /// Paused UI를 관리하는 클래스
        /// Paused UI 활성화,비활성,x,메인메뉴,다시하기 버튼 기능
        /// </summary>

        #region Variables
        public GameObject pausedUI;

        //씬 페이더
        public SceneFader fader;
        //메뉴 씬 이름
        [SerializeField]
        private string loadToScene = "MainMenu";
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Esc 키 입력시 Pause활성화, 다시 Esc키 입력시 비활성화
            if (Input.GetKeyDown(KeyCode.Escape))
            { Toggle(); }
        }
        #endregion 
        #region Custom Method
        public void Toggle()
        {
            /*if (pausedUI.activeSelf == false)
            { pausedUI.SetActive(!pausedUI.activeSelf); }

            else if (pausedUI.activeSelf == true)
            { pausedUI.SetActive(!pausedUI.activeSelf); } */
                pausedUI.SetActive(!pausedUI.activeSelf); //! > 현재 상태와 반대 상태로 

            //pause 상태인지
            if (pausedUI.activeSelf )
            { Time.timeScale = 0f; }
            else //pause 상태가 아닌지
            {
                Time.timeScale = 1f;
            }

        }
        public void MainMenu()
        {
            fader.FadeTo(loadToScene);
            Time.timeScale = 1f;
        }
        public void Restart()
        {
            //웨이브,돈,라이프 초기화,타워 제거
            //현재 플레이 하고 있는 씬을 다시 호출
            //SceneManager.LoadScene(0);  = 씬 빌드번호로 호출
           int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;

            /*int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(nowBuildIndex);*/

            fader.FadeTo(nowBuildIndex);

            Time.timeScale = 1f;

        }
        #endregion
    }
}