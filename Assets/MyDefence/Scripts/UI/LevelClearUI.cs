using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 레벨 클리어 UI관리하는 클래스
    /// </summary>
    public class LevelClearUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "MainMenu";
        [SerializeField]
        private string nextScene = "Level02";
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //NextLevel 버튼 클릭시 호출
        public void NextLevel()
        {
            fader.FadeTo(nextScene);

        }
        #endregion
        //MainMenu 버튼 클릭시 호출
        public void MainMenu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}
