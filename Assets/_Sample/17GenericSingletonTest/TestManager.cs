using Sample;
using UnityEngine;

namespace sample
{
    /// <summary>
    /// Singleton<T>을 상속받는 테스트 크래스
    /// </summary>
    public class TestManager : Singleton<TestManager>
    {
        public int number =1234;
    }
}