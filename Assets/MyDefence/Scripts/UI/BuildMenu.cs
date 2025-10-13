using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    public class BuildMenu : MonoBehaviour
    {
        public void SelectMachineGun()
        {
            //Debug.Log("머신건 타워를 선택했습니다.");

            //turretToBuild = machineGunPrefab;
            BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.mechinGunPrefab);
        }
        public void anotherMachineGun()
        {
            Debug.Log("다른 타워를 선택했습니다.");
           
        }
    }
}