using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타일 UI를 관리하는 클래스
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        #region Variabels
        //타일 ui오브젝트
        public GameObject ui;

        //선택된 타일
        private Tile targetTile;
        #endregion

        #region Unity Event Method
        #endregion

        #region Custom Method
        //타일 UI보여주기(매개변수로 선택된 타일 정보를 가져온다)
        public void ShowTileUI(Tile tile)
        {
            //내가 선택한 타일 위치에서 보여주기
            targetTile = tile;

            this.transform.position = this.transform.localPosition;
            ui.SetActive(true); 
        }

        //타일 UI숨기기
        public void HideTileUI()
            
        {
            targetTile = null;
            ui.SetActive(false);
        }

        //업그레이드 버튼을 선택했습니다
        public void UpgradeTower()
        {
            Debug.Log("설치된 타워를 업그레이드 합니다");
            targetTile.UpgradeTower();
        }

        //셀 버튼을 선택했습니다.
        public void Sell()
        {
            Debug.Log("타워를 판매 합니다");
        }
        #endregion
    }
}