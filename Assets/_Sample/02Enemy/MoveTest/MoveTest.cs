using UnityEngine;

namespace Sample
{
    public class MoveTest : MonoBehaviour
    {

        //이동 목표 지정 변수
        private Vector3 targetPosition = new Vector3(7f, 1f, 8f);
        //이동 목표 위치에 있는 오브젝트의 트랜스폼 인스턴스
        public Transform target;

        //이동 속도를 저장하는 변수를 선언하고 초기화
        public float Speed = 5f; //1초에 가는 거리


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            /* this.gameObject.transform
             this.transform.gameObject*/
            //this.transform.position = new Vector3(7f, 1f, 8f);
            // Debug.Log(this.transform.position);

            /*this.transform.position = Target.position;
            Debug.Log(Target.position); > 순간이동 */
        }

        // Update is called once per frame
        void Update()
        {
            //플레이어의 위치를 앞으로 계속 이동 : z축 값이 증가한다
            //this.transform.position 연산으로 구현 - Vector3
            #region  앞,뒤,좌,우,위,아래 이동
            //this.transform.position += Vector3.forward;

            /*Vector3(0f, 0f, 1f); Vector3.forward
            Vector3(0f, 0f, -1f); Vector3.back
            Vector3(-1f, 0f, 0f); Vector3.left
            Vector3(1f, 0f, 0f); Vector3.right
            Vector3(0f, 1f, 0f); Vector3.up
            Vector3(0f, -1f, 0f);Vector3.down
            Vector3(1f, 1f, 1f); Vector3.one - 단위벡터 
            Vector3(0f, 0f, 0f); Vector3.zero - 리셋 */
            #endregion

            #region 앞 방향으로 1초에 1unit 만큼씩 이동하라
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
            //혹은 this.transform.position += new Vector3.forward * Time.deltaTime;
            #endregion

            #region 앞 방향으로 1초에 5만큼씩 이동하라
            //this.transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * Speed;
            #endregion

            #region Translate
            //dir(방향) : 이동할 방향
            //Time.deltaTime : 동일한 시간에 동일한 거리를 이동하게 해준다
            //speed : 이동의 빠르기 지정
            //dir * Time.deltaTime*speed => 연산의 결과는 Vector3
            //transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            #endregion

            #region 이동 방향 구하기 : (목표지점 - 현재지점) or (도착위치 - 현재위치)
            //dir.normalized : 단위벡터, 길이가 1인 벡터,정규화된 벡터
            //dir.magnitude : 벡터의 길이,크기
            Vector3 dir = target.position - this.transform.position;
            //[1] this.transform.Translate(dir.normalized*Time.deltaTime*Speed);
            //[2] - 1,2 동일함
            this.transform.Translate(dir.normalized * Time.deltaTime, Space.Self);

            #endregion
        }
    }
}
/*
n프레임 : 초당 n번 실행 
20프레임

Time.deltaTime : 한 프레임 돌아오는데 걸리는 시간 (0.1초)

성능 좋은 컴
10프레임 - 1초에 10unit 이동(Time.deltaTime 을 고려하지 않았을 때)
10프레임 - 1초에 1unit 이동(Time.deltaTime 을 고려했을 때)
Time.deltaTime : 0.1

        this.transform.position += Vector3(0f, 0f, 1f)* Time.deltaTime > 0.1씩 증가


성능 나쁜  컴
2프레임 - 1초에 2unit 이동
Time.deltaTime : 0.5
.        this.transform.position += Vector3(0f, 0f, 1f)* Time.deltaTime > 0.5씩 증가

*/