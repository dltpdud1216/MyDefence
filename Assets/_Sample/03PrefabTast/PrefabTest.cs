using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        #region Variables 프리팹오브젝트
        public GameObject prefab;   // 생성할 타일(4*4) 프리팹

        //맵 타입의 부모 오브젝트
        //public GameObject Parent;

        //맵 타일 생성 체크
        bool isCreate = false;

        #endregion

        #region Unity Event Method
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            #region 맵 타일 생성하기
            //[1]
            //Instantiate(prefab);
            //위치: (5,0,8) 맵타일 생성하기
            //Instantiate(prefab,위치,방향);
            /* [1]
             Vector3 position = new Vector3(5f, 0f, 8f);
             Instantiate(prefab,position, Quaternion.identity);*/
            /*[2]
             Instantiate(prefab, new Vector3(5f, 0f, 8f),Quaternion.identity);
            */
            #endregion
            //GenerateMap(10,10);

            //랜덤타일찍기
            //GenerateRandomMapTile();

            //랜덤 타일을 1초 간격으로 10개 찍는다
            //타일 하나찍고 -> 1초 쉬었다가(딜레이) -> 타일 하나 찍고 -> 1초 쉬었다가

        }
        #endregion
        private void Update()
        {
            if (isCreate == false)
            {
                StartCoroutine(CreateMapTile());

                isCreate = true;
                Debug.Log($"타일 생성 완료{isCreate}");
            }
            Debug.Log($"업데이트 내용 실행");

        }

        #region Custum Method 10*10 (1간격)만들기
        //[1] 
        void GenerateMap(int row, int column)
        {

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(i * 5f, 0f, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity);
                }
            }
        }
        #endregion
        #region 맵 제네레이터를 부모로 지정하며 맵 타일 찍기
        //[2]
        void GenerateMapTile(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    /*인스턴스시 위치 지정
                     * Vector3 position = new Vector3(i * 5f, 0f, j * -5f);
                    Instantiate(prefab, position, Quaternion.identity,this.transform);*/

                    //인스턴스 후 위치 지정 - 생성된 게임오브젝트 객체 가져오기
                    GameObject go = Instantiate(prefab, this.transform);
                    go.transform.position = new Vector3(i * 5f, 0f, j * -5f);
                }
            }
        }
        #endregion
        #region row(10)행 x column(10)열 중에 랜덤한 위치에 타일 하나 찍기
        void GenerateRandomMapTile()
        {
            //int row = Random.Range(0, 10);
            //int column = Random.Range(0, 10);

            //0 1 2 3 ... => r: 0, c:0~9
            //10 11 12 13 ... => r:1 ,c:0~9
            //20 21 22 23 ... => r:2 ,c:0~9

            int randNumber = Random.Range(0, 100);
            int row = randNumber / 10;
            int column = randNumber % 10;

            Vector3 position = new Vector3(row * 5f, 0f, column * -5f);
            Instantiate(prefab, position, Quaternion.identity);
        }
        #endregion
        #region 코루틴 함수
        IEnumerator CreateMapTile()
        {
           /* GenerateRandomMapTile();
            Debug.Log("첫번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("두번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("세번째 타일 생성");
            yield return new WaitForSeconds(1.0f);

            GenerateRandomMapTile();
            Debug.Log("네번째 타일 생성");
            yield return new WaitForSeconds(1.0f);*/

            for (int i = 0;i < 10;i++)
            {
                GenerateRandomMapTile();
                Debug.Log($"{i+1} 타일 생성");
                yield return new WaitForSeconds(1.0f);

            }


        }

        #endregion

    }
}

/*
코루틴 함수 : 지연 함수
-하나이상의 Yield return문의 꼭 있어야 한다
-Yield return 문에서 지연 시간 지정 할 수 있다.
-Yield return new WaitForSeconds(지연시간(초));


형식
IEnumerator 함수이름()
{
    //...
    Yield return ... 
}

코루틴 함수 호출
StrartCoroutine(코루틴 함수이름);

*/
