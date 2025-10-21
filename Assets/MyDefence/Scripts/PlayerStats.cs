using TMPro;
using UnityEngine;

namespace MyDefence
{
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;
        //게임 Life
        private static int live;

        //초기 소지 골드
        [SerializeField]
        private int startMoney = 400;
        //초기 소지 생명
        [SerializeField]
        private int startlive = 10;

        //웨이브 카운트
        private static int rounds;
        #endregion

        #region Property
        //소지금 읽기전용 속성
        public static int Money
        {
            get { return money; } 
        }
        //생명 개수 읽기 전용 속성
        public static int Live
        {
            get { return live; }
        }
        //웨이브 카운트 속성
        public static int Rounds
        { get { return rounds; }
            set { rounds = value; } }
        #endregion
        #region Unity Event Method
        private void Start()
        {
            //초기화
            //게임을 진행했으면 저장된 데이터를 가져와서 소지금 초기화

            money = startMoney; //초기 소지금 지급
            live = startlive; //초기 생명 갯수 지급
            rounds = 0; //웨이브 카운트 초기화

        }
        #endregion

        #region Custom Methods
        public static void AddMoney(int amount)
        {
            money += amount;
        }
        public static bool Usemoney(int amount)
        {
            if(money < amount)
            {
                Debug.Log("돈이 부족합니다.");
                   return false;
            }
            money -= amount;
            return true;
        }

        //소지금 체크
        public static bool HasMoney(int amunt)
        { 
            return money >= amunt; 
        }

        //Life 벌기
        public static void AddLife(int amount)
        {
            live += amount;
        }

        //Life 쓰기
        public static void UseLife(int amount)
        {
            live -= amount;
            if (live < 0)
                            live = 0;
            
        }
        #endregion
    }
}