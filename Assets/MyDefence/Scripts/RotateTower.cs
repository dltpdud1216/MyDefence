using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 타워를 회전시켜주는 클래스
    /// </summary>
    public class RotateTower : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        public Vector3 rotationSpeed = new Vector3(0, 50f, 0); // X,Y,Z축 회전 속도
        #endregion

        #region Unity Event Method
        
        private void Update()
        {
            transform.localEulerAngles += rotationSpeed;
        }
        #endregion
    }
}