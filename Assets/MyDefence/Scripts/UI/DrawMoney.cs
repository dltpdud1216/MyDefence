using UnityEngine;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 게임 중 가지고 있는 Money를 그리는 UI 클래스
    /// </summary>
    public class DrawMoney : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI moneyText;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            moneyText.text = PlayerStats.Money.ToString();
        }
    }
        #endregion
    }
