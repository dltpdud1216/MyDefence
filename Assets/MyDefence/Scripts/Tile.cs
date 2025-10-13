using MyDefence;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sample
{
    /// <summary>
    /// 맵 타일을 관리하는 클래스 
    /// </summary>
    public class Tile : MonoBehaviour
    {
        #region Variables
        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;

        //랜더러 컨포넌트 인스턴스 변수 선언
        private Renderer renderer;

        private Color originalColor;
        private Material originalMaterial;

        //마우스가 들어가면 바뀌는 컬러
        public Material hoverMaterial;

        //타워 건설
        public GameObject towerprefab;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            renderer = GetComponent<Renderer>();
            if (renderer != null)
                originalColor = renderer.material.color;
        }
        private void OnMouseDown()
        {

            //타일이 ui로 가려져 있으면 설치 못한다
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            //만약 타일에 타워오브젝트가 있으면 설치하지 않기
            if (tower != null)
            {
                Debug.Log("타워가 이미 설치되어 있습니다");
                return;
            }
            //만약 타워를 선택하지 않았으면 변경되지 않는다
            if (BuildManager.Instance.GetTurretToBuild() == null)
            {
                return;
            }
            renderer.material = originalMaterial;



            BuildTower();
        }

        private void OnMouseEnter()
        {
            if (renderer != null)
                renderer.material = hoverMaterial;
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }
        private void OnMouseExit()
        {
            if (renderer != null)
                renderer.material = originalMaterial;
                renderer.material.color = originalColor;

        }
        #endregion

        #region Custom Method
        //타워 건설
        private void BuildTower()
        {
            tower = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position, Quaternion.identity);

            //turretToBuild = null; 건설 후 다시 건설하지 못하게 한다
            BuildManager.Instance.SetTurretToBuild(null);

        }
        #endregion
    }
}