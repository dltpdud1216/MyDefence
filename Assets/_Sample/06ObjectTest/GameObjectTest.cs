using UnityEngine;

/*
(하이라키 창에 있는) 게임 오브젝트의 GameObject 또는 transform에 접근하는 방법
GameObject 또는 transform 인스턴스를 가져오는 방법

1) 접근할 게임오브젝트에 직접 스크립트 소스를 컴포넌트로 추가하여 직접(this) 가져온다
2) 접근할 다른 게임 오브젝트의 gameobject, transform 인스턴스 변수를 public한 필드로 선언 후 인스펙터 창에서 드래그로 직접 가져온다
3) Find - 유니티에서 제공하는 API를 이용하여  gameobject, transform 인스턴스를 반환
 EX : GameObject.FindGameObjectsWithTag (여러개), GameObject.FindGameObjectWithTag
4) prefab 게임 오브젝트 생성시 Instantiate함수의 반환값으로 gameobject객체를 가져온다
5) 같은 종류, 같은 기능들로 묶여 있는 게임 오브젝트의 gameobject, transform 인스턴스 가져오기
6) static 이용 : 싱글톤 패턴
 - static 필드 : 클래스이름.필드이름
*/


namespace Sample
{
    public class GameObjectTest : MonoBehaviour
       
    {
         //2-1) public 필드 선언
        public GameObject publicObject;
        public Transform publicTransform;

        //3-1) Find API 중 tag를 이용하여 gameobject, transform 인스턴스 가져오기
        private GameObject[] tagObjects; //여러개
        private GameObject tagObject; //한 개

        //4-1) Prefab 오브젝트 가져오기
        public GameObject gameobjectPrefab;

        //5-1) 부모 오브젝트 만들고 같은 종류,기능을 가진 오브젝트들을 자식 오브젝트로 추가한다
        //부모 오브젝트의 객체를 통해 자식 오브젝트들의 gameobject, transform 인스턴스 가져오기
        public Transform ParentObject;
        private Transform[] childObjects;

        void Start()
        {
            //1) this
            // 1-1 this.gameObject
            // 1-2 this.transform
            // 1-3 this.gameObject.transform
            // 1-4 this.transform.gameObject

            //2-2)
            //publicObject.GetComponent<>()
            //publicTransform.position

            //3-2)
            //GameObject.FindGameObjectsWithTag
            tagObjects = GameObject.FindGameObjectsWithTag("Enemy");
            tagObject = GameObject.FindGameObjectWithTag("Enemy");

            //4-2)
            GameObject prefabGo = Instantiate(gameobjectPrefab,this.transform.position,Quaternion.identity);

            //5-2) 부모와 자식관의 관계를 이용하여 게임 오브젝트들의 transform 인스턴스 가져오기
            //childCount: 자식오브젝트의 갯수, Getchild(index): index번째 자식 인스턴스 반환
            childObjects = new Transform[ParentObject.childCount];
            for (int i = 0; i < childObjects.Length; i++)
            {
                childObjects[i] = ParentObject.GetChild(i);
            }
        }
    }
}