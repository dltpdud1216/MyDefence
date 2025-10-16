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

        //싱글톤(객체)선언
        private BuildManager buildManager;

        //타일에 설치된 타워 오브젝트 인스턴스
        private GameObject tower;
        //타일에 설치된 타워 오브젝트 blueprint 정보 객체(프리팹,가격,설치조정위치)
        private TowerBlueprint blueprint;

        //랜더러 컨포넌트 인스턴스 변수 선언
        private Renderer renderer;

        private Color startColor;
        private Material originalMaterial;

        //마우스가 들어가면 바뀌는 컬러
        public Material hoverMaterial;
        private Material startMaterial;

        //건설 비용 부족 시 바뀌는 메터리얼
        public Material moneyMaterial;

        //타워 건설
        public GameObject towerprefab;

        //타워 건설 효과
        public GameObject buildEffectprefab;
        #endregion

        #region Unity Event Method

        private void Start()
        {
            renderer = this.transform.GetComponent<Renderer>();
            buildManager = BuildManager.Instance;

            //초기화
            startColor = renderer.material.color;
            startMaterial = renderer.material;

        }
        private void OnMouseDown()
        {

            //타일이 ui로 가려져 있으면 설치 못한다
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            //만약 타워를 선택하지 않았으면 변경되지 않는다
            if (buildManager.CannotBuild)
            {
                return;
            }
            //만약 타일에 타워오브젝트가 있으면 설치하지 않기
            if (tower != null)
            {
                Debug.Log("타워가 이미 설치되어 있습니다");
                return;
            }
            if (buildManager.HasBuildCost)
            {
                renderer.material = hoverMaterial;
            }
            else
            {
                renderer.material = moneyMaterial;
                return;
            }    
                blueprint = buildManager.GetTurretToBuild();



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
            //renderer.material.color = startColor;
            renderer.material = startMaterial;
            startColor = renderer.material.color;

        }
        #endregion


        #region Custom Method
        //타워 건설
        private void BuildTower()
        {
            //건설비용 체크
            if(buildManager.HasBuildCost==false)
            {   
                Debug.Log("건설 비용이 부족합니다.");

                return;
            }
            //건설 비용 지불
            PlayerStats.Usemoney(blueprint.cost);

            tower = Instantiate(blueprint.prefab, this.transform.position+ blueprint.offsetPos, Quaternion.identity);

            //건설 이펙트 효과
            GameObject effectGo = Instantiate(buildEffectprefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            //turretToBuild = null; 건설 후 다시 건설하지 못하게 한다
            buildManager.SetTurretToBuild(null);
            Debug.Log($"건설하고 남은 소지금:: {PlayerStats.Money}");

        }
        #endregion
    }
}