using UnityEngine;

namespace MyDefence
{

    public class LookAtCamera : MonoBehaviour
    {
        #region Variables
        private Camera mainCamera;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            //항상 메인카메라를 바라보도록 한다
            //transform.LookAt(mainCamera.transform);
            //카메라의 x포지션을 오브젝트의 x포지션과 동일하기 한다
            Vector3 targetPosition = new Vector3(mainCamera.transform.position.x,
                mainCamera.transform.position.y, mainCamera.transform.position.z);
            transform.LookAt(targetPosition);
        }
        #endregion

        #region Custom Method
        #endregion
    }
}