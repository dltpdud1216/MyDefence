using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        #region Variables
        private BuildManager buildManager;

        //타워 리스트
        public TowerBlueprint machineGun;
        public TowerBlueprint rocketTower;
        public TowerBlueprint LaserTower;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            buildManager = BuildManager.Instance;
        }
        #endregion
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택했습니다.");

            //turretToBuild = machineGunPrefab;
            //BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.mechinGunPrefab); 요약 >>
            buildManager.SetTurretToBuild(machineGun);
        }
        public void SelectRocketTower()
        {

            buildManager.SetTurretToBuild(rocketTower);

        }
        public void SelectLaserTower()
        {

            buildManager.SetTurretToBuild(LaserTower);

        }
    }
}