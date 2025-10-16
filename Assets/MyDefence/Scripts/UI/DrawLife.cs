using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임 중 가지고 있는 Money를 그리는 UI 클래스
    /// </summary>
    public class DrawLife : MonoBehaviour
    {
        #region Variables
        //Life UI : 생명 갯수
        public TextMeshProUGUI LifeText;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            //Life 데이터 UI 적용
            LifeText.text = PlayerStats.Live.ToString();
        }
    }
    #endregion
}

