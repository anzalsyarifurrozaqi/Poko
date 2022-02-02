using UnityEngine;

namespace anzal.game
{
    public class SpawnProjectile : CharacterFunction
    {                
        public override void RunFunction()
        {
            Vector3 shootDir = control.DATASET.ENEMY_DATA.closestEnemy.transform.position - control.Weapon.transform.position;            

            GameObject smokeWeapon = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.SMOKE_WEAPON);            
            smokeWeapon.SetActive(true);                        
            smokeWeapon.transform.position = control.Weapon.transform.position + smokeWeapon.transform.forward;
            smokeWeapon.transform.rotation = control.Weapon.transform.rotation;

            GameObject projectileObj = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.PROJECTILE);
            projectileObj.SetActive(true);
            projectileObj.GetComponent<Projectile>().RegisterProjectil(control, shootDir);
        }
    }
}