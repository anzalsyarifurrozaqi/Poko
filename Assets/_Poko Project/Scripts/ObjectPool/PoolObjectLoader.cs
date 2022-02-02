using UnityEngine;

namespace anzal.game
{    
    public class PoolObjectLoader : MonoBehaviour
    {
        static string AttackCondition = "AttackCondition";
        static string Projectile = "Projectile";        
        static string SmokeEquipment = "SmokeEquipment";
        static string SmokeWeapon = "SmokeWeapon";
        static string SmokeHit = "SmokeHit";
        static string Ground = "Ground";
        static string EnemyMushroomTypeB = "Enemy_Mushroom_Type_B";
        static string PathFindingAgent = "PathFindingAgent";

        public static PoolObject InstantiatePrefab(PoolObjectTypeEnum objType)
        {
            GameObject obj = null;

            switch(objType)
            {
                case PoolObjectTypeEnum.ATTACK_CONDITION:
                    {
                        obj = Instantiate(Resources.Load(AttackCondition, typeof(GameObject)) as GameObject);
                        break;
                    }               

                case PoolObjectTypeEnum.PROJECTILE:
                    {
                        obj = Instantiate(Resources.Load(Projectile, typeof(GameObject))) as GameObject;
                        break;
                    }

                case PoolObjectTypeEnum.SMOKE_HIT:
                    {
                        obj = Instantiate(Resources.Load(SmokeHit, typeof(GameObject))) as GameObject;
                        break;
                    }

                case PoolObjectTypeEnum.SMOKE_EQUIPMENT:
                    {
                        obj = Instantiate(Resources.Load(SmokeEquipment, typeof(GameObject))) as GameObject;
                        break;
                    }

                case PoolObjectTypeEnum.SMOKE_WEAPON:
                    {
                        obj = Instantiate(Resources.Load(SmokeWeapon, typeof(GameObject))) as GameObject;
                        break;
                    }

                case PoolObjectTypeEnum.GROUND:
                    {
                        obj = Instantiate(Resources.Load(Ground, typeof(GameObject))) as GameObject;
                        break;
                    }
                    
                case PoolObjectTypeEnum.ENEMY_MUSHROOM_TYPE_B:
                    {
                        obj = Instantiate(Resources.Load(EnemyMushroomTypeB, typeof(GameObject))) as GameObject;
                        break;
                    }

                case PoolObjectTypeEnum.PATH_FINDING_AGENT:
                    {
                        obj = Instantiate(Resources.Load(PathFindingAgent, typeof(GameObject))) as GameObject;
                        break;
                    }
            }

            return obj.GetComponent<PoolObject>();
        }
    }
}
