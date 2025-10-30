using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    /// <summary>
    /// 게임오버 UI를 관리하는 클래스
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        public SceneFader fader;
        [SerializeField]
        private string loadToSene = "MainMenu";

        #region Variables
        //Rounds 텍스트
        public TextMeshProUGUI roundsText;
        #endregion

        #region Unity Event Method
        //게임오버 UI가 활성화 될 때 playerStats Round 값을 한 번만 가져온다
        private void OnEnable()
        {
            //텍스트에 playerStats Round 값 적용
             roundsText.text = PlayerStats.Rounds.ToString() + " Rounds Survived";
        }
        /* private void Update()
         {
             //매 프레임마다 Rounds 텍스트에 playerStats Round 값 적용
             roundsText.text = PlayerStats.Rounds.ToString() + " Rounds Survived";
         }*/
        #endregion

        #region Custom Meshod
        //메인 메뉴 버튼을 눌렀을때 호출
        public void MainMenu()
        {
            //Debug.Log("Goto MainMenu!!");
            fader.FadeTo(loadToSene);
        }

        //게임 재시작 버튼 눌렀을때 호출
        public void Restart()
        {
            Debug.Log("Restart");

            //웨이브,돈,라이프 초기화,타워 제거
            //현재 플레이 하고 있는 씬을 다시 호출
             /*SceneManager.LoadScene(0);  = 씬 빌드번호로 호출
            int nowBuildIndex = SceneManager.GetActiveScene().buildIndex;*/

            string nowSceneName = SceneManager.GetActiveScene().name;
            fader.FadeTo("nowSceneName"); //씬 이름으로 호출

        }
        #endregion
    }

}