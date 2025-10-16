using UnityEngine;

namespace Sample
{
    /// <summary>
    /// 직렬화 예제, unity에서 직렬화: 인스펙터창에서 편집 가능하게 하는 것
    /// </summary>

    [System.Serializable]
    public struct TestStruct
    {
        public float Value1;
        public int Value2;
    }
    public class SeriallTest : MonoBehaviour
    {
        public int number = 10;

        [SerializeField]
        private string name = "홍길동";

        public TestStruct testStruct;
    }
}