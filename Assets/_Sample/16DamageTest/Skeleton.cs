using UnityEngine;
using MyDefence;

namespace Sample
{
    /// <summary>
    /// IDamageable을 상속받은 몬스터 클래스
    /// </summary>
    public class Skeleton : MonoBehaviour,IDamageable
    {
        #region Variavles
        //체력
        protected float health;

        //체력 초기값
        [SerializeField]
        protected float startHealth = 1f;

        //죽음 체크
        protected bool isDeath = false;
        #endregion

        #region Unity Event Method
        protected virtual void Start()
        {
            health = startHealth;
        }
        #endregion

        #region Custom Method
        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0f && isDeath == false)
            {
                Die();
            }
        }
        protected virtual void Die()
        {
            isDeath = true;

            //Kill
            Destroy(gameObject);
        }
        #endregion

        public void TakeDamage(float damage)
        {

        }
    }
}