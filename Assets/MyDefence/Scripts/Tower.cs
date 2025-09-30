using UnityEngine;
using System.Collections;

using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 타워를 관리하는 클래스
    /// </summary>
    public class Tower : MonoBehaviour
    {
        #region Variables
        //공격 타겟 Enemy - 가장 가까운 적
        private GameObject target;

        //회전
        public Transform partToRotate; //회전을 관리하는 오브젝트
        public float rotateSpeed = 10f; //회전 속도

        //공격 범위
        public float attackRange = 7;

        //찾기 타이머
        public float searchTimer = 0.2f;
        private float countdown = 0f;
        #endregion
        private void Start()
        {
            //초기화
            countdown = searchTimer;
        }

        private void Update()
        {

            //0.2초마다 가장 가까운 적 찾기
            if(countdown <= 0f)
            {
                //타이머 기능 
                UpdateTarget();

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            if (target == null)
                            return;
           
                //타겟을 향해서 partToRotate 회전
                Vector3 dir = target.transform.position - this.transform.position;

                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Quaternion lerpRotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed);
                Vector3 eulerValue = lerpRotation.eulerAngles;
                //y축만 회전하기
                partToRotate.rotation = Quaternion.Euler(0f, eulerValue.y, 0f);
           
        }
        #region Unity Event Method 기즈모
        private void OnDrawGizmosSelected()
        {
            //타워중심에 attackRange 범위 확인
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,attackRange);
        }
        #endregion

        #region Custom Method
        //타워에서 가장 가까운 적 찾기
        void UpdateTarget()
        {
            //맵 위에 있는 모든 enemy 게임 오브젝트 가져오기
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            //최소거리 변수 초기화
            float minDistance = float.MaxValue;
            //최소거리에 있는 게임오브젝트 변수
            GameObject nearEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                //enemy와의 거리 구하기
                float distance = Vector3.Distance(transform.position,enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            } 
            // 가장 가까운 적을 찾았다, 이때 최소거리는 공격 범위보다 작아야 한다
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy;
            }
            else
            {
                target = null;
            }    
        }
        #endregion
    }
}