using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefence
{
    /// <summary>
    /// 미사일 발사체를 관리하는 클래스, Bullet을 상속 받는다
    /// </summary>
    public class Rocket : Bullet
    {
        #region Variables
        public float damageRange = 3.5f; //폭발 범위
        #endregion

        #region Unity Event Method
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, damageRange);
        }
        #endregion

        #region Custom Method
        protected override void HitTarget()
        {
            //타격위치에 이펙트를 생성한 후 2초 뒤에 타격 이펙트 오브젝트 kill
            GameObject effectGo = Instantiate(Impactprefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 3f);

            //Debug.Log("Hit Enemy!!!");
            //demafeRange 반경 안에 있는 모든 적에게 데미지 주기
            Explosion();

            //탄환 킬
            Destroy(this.gameObject);
        }
        //demafeRange 반경 안에 있는 모든 적에게 데미지 주기
        private void Explosion()
        {
            //데미지 범위안에 있는 모든 충돌체 가져오기
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);

            //모든 충돌체 중에서 enemy 찾아서 데미지 주기
            foreach (Collider collider in hitColliders)
            {
                //enemy 찾기(태그 검사)
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);

                }
            }
        }
        #endregion
    }


}