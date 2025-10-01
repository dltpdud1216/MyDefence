using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using TMPro;

namespace MyDefence
{
    /// <summary>
    /// 적 스폰 및 웨이브를 관리하는 클래스
    /// </summary>
    public class WaveSpawnManager : MonoBehaviour
    {
        #region Variable 적 프리팹 오브젝트 - 원본
        public GameObject EnemyPrefab;
        //public Transform Spawn; = this.transform

        //스폰(5초) 타이머
        public float spawnTimer = 5f;  //타이머 기준 시간
        private float countdown = 0f;   //시간 누적 변수

        //웨이브 카운트
        private int WaveCount = 0;

        //UI
        public TextMeshProUGUI countdownText;

        #endregion

        #region Unity Event Method
        private void Start()
        {
            //EnemySpawn();
        }

        private void Update()
        {
            //스폰(5초) 타이머
            countdown += Time.deltaTime;
            if (countdown >= spawnTimer)
            {
                //타이머 기능 실행
                StartCoroutine( SpawnWave());
                //타이머 초기화
                countdown = 0f;
            }

            //UI - 카운트다운 텍스트
            //countdown 특정 범위 MIn,Max 설정 (- 값이 안되도록 설정)
            countdown = Mathf.Clamp(countdown, 0f,Mathf.Infinity);
            countdownText.text = string.Format("{0:00.00}",countdown); // 실수(소수점 이하)출력
            //##.##으로 출력 시 0은 안찍힘
            countdownText.text = Mathf.Round(countdown).ToString(); //Round = 반올림/ 반오림하여 정수형 출력

        }
        #endregion

        #region Custum Method
        //enemy 스폰 웨이브
        IEnumerator SpawnWave()
        {
            WaveCount++;

            //0.5초 지연하여 enemy스폰
            for (int i = 0; i < WaveCount; i++)
            {
                EnemySpawn();
                yield return new WaitForSeconds(0.5f);
            }
        }
        //시작점 위치에 enemy 1개 생성
        void EnemySpawn()
        {
            Instantiate(EnemyPrefab, this.transform.position, Quaternion.identity);
        }
        #endregion

    }
}
