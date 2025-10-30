using System.Xml.Serialization;
using UnityEngine;

namespace MyDefence
{
    /// <summary>
    /// 인터벌 시간 간격으로 파티클 이펙트를 플레이 시켜주는 클래스
    /// </summary>
    public class IntervalParticleSystem : MonoBehaviour
    {
        #region Variables
        //연출 파티클
        public ParticleSystem particleToPlay;

        [SerializeField ]
        //플레이 타이머
        private float playTimer = 5f;
        private float countdown = 0f;
        #endregion

        #region Unity Event Method
        private void Start()
        {
            //일정시간마다 한 번씩 지정하는 함수를 호출하라
            InvokeRepeating("PlayParticleSystem", 0f, playTimer);
        }
        private void Update()
        {
            /*// 파티클 플레이 타이머
            countdown += Time.deltaTime;

            // 시간이 다 되면 파티클 재생
            if (countdown >= playTimer)
            {
                PlayParticleSystem();

                // 타이머 초기화
                countdown = 0f ;
            }*/
        }
        #endregion

        #region Custom Method
        private void PlayParticleSystem()
        {
            if (particleToPlay == null)

                return;

                particleToPlay.Play();
            
        }
        #endregion
    }
}