using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 레이저를 쏘는 타워를 관리하는 클래스,tower 상속 받는다
    /// </summary>
    public class LaserTower : Tower
    {
        #region Variables
        //레이저 빔
        private LineRenderer lineRenderer;

        //레이저 빔 타격 이펙트
        public ParticleSystem laserImpact;

        //레이저 빔 타격 라이팅
        public Light ImpactLight;

        //1초당 30 데미지
        [SerializeField]
        private float laserDamage = 30f;
        //이동 속도 40%감속
        [SerializeField]
        private float slowrate = 0.4f;
        
        #endregion

        #region Unity Event Method
        protected override void Start()
        {
            base.Start();
            //LineRenderer 컴포넌트 가져오기
            lineRenderer = GetComponent<LineRenderer>();
        }

        protected override void Update()
        {

            //0.2초마다 가장 가까운 적 찾기
            if (countdown <= 0f)
            {
                //타이머 기능 
                UpdateTarget();

                //타이머 초기화
                countdown = searchTimer;
            }
            countdown -= Time.deltaTime;

            if (target == null)
            {
                //레이저를 그리지 않는다
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpact.Stop();
                    ImpactLight.enabled = false;

                }
                return;
            }
            //타겟을 향해서 partToRotate 회전
            LockOn();

            //레이저 빔 쏘기
            Shootlaser();

        }
        #endregion

        #region Custom Method
        private void Shootlaser()
        {
            //데미지 주기 
            float frameDamage = Time.deltaTime * laserDamage; //프레임 당 데미지 계산
            EnemyMove enemy = target.GetComponent<EnemyMove>();

            if (enemy != null)
            {
                enemy.TakeDamage(frameDamage);
                //이동속도
                enemy.Slow(slowrate);
            }
            /*damageCountdown += Time.deltaTime;
            if (damageCountdown >= damageTimer)
            {
                     *damageCountdown +//타이머 기능 - 30데미지
                     EnemyMove enemy = target.GetComponent<EnemyMove>();
                if (enemy != null)
                {
                    enemy.TakeDamage(laserDamage);
                }
                //타이머 초기화
                damageCountdown = 0f;
            }*/
            //라인 렌더러 활성화
            if (lineRenderer.enabled == false)
            {
                //라인 렌더를 그린다.
                lineRenderer.enabled = true;
                laserImpact.Play();
                ImpactLight.enabled = true;
            }
            //라인 런더러의 시작,끝 지점 지정
            lineRenderer.SetPosition(0, firePoint.position); //라인 시작 지점
            lineRenderer.SetPosition(1, target.transform.position); //라인 끝 지점

            //레이저 타격 임펙트
            Vector3 dir = target.transform.position - laserImpact.transform.position; //타격 이펙트가 파이어포인트를 바라보는 방향
            laserImpact.transform.position = target.transform.position+dir.normalized/2;
            laserImpact.transform.rotation = Quaternion.LookRotation(dir); //타격 이펙트가 타겟을 바라보도록 회전
        }
         #endregion
    }
}