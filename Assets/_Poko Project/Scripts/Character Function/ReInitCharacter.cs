using UnityEngine;
using UnityEngine.AI;

namespace anzal.game
{
    public class ReInitCharacter : CharacterFunction
    {
        private RagdoolData _ragdollData => control.DATASET.RAGDOLL_DATA;
        private BlockingData _blockingData => control.DATASET.BLOCKING_OBJ_DATA;
        private DeadData _deadData => control.DATASET.DEAD_DATA;
        private DamageData _damageData => control.DATASET.DAMAGE_DATA;
        private AttackData _attackData => control.DATASET.ATTACK_DATA;
        private FallenData _fallenData => control.DATASET.FALLEN_DATA;
        public override void RunFunction()
        {            
            _ragdollData.Hip.Transform.localPosition = Vector3.zero;
            _ragdollData.Hip.Transform.localRotation = Quaternion.identity;
            _blockingData.DownBlockingObjects.Clear();

            control.BOX_COLLIDER.enabled = true;

            _deadData.Dead = false;
            _damageData.hp = 10;
            _fallenData.Fallen = false;
            _attackData.isAttackAble = true;
            _ragdollData.IsRagdoll = false;            
            _ragdollData.RagdollStateEnum = RagdollStateEnum.Animated;

            control.gameObject.layer = LayerMask.NameToLayer(GameLayerEnum.ENEMY.ToString());

            if (control.aiController == null)
            {
                control.aIProgress = control.GetComponentInChildren<AIProgress>();
                control.aiController = control.GetComponentInChildren<AIController>();
                control.GetComponent<NavMeshObstacle>().enabled = false;
            }            

            RegisterCharacter();            
        }

        void RegisterCharacter()
        {
            if (!CharacterManager.Instance.Characters.Contains(control))
            {
                CharacterManager.Instance.Characters.Add(control);
            }
        }        
    }
}