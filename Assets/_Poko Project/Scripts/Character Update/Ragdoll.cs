using UnityEngine;
using UnityEngine.AI;

namespace anzal.game
{    
    public class Ragdoll : CharacterUpdate
    {
        public float Blend = 0.25f;
        public float Timer = 1f;

        private RagdoolData _ragdollData => control.DATASET.RAGDOLL_DATA;
        private DeadData _deadData => control.DATASET.DEAD_DATA;
        private AttackData _attackData => control.DATASET.ATTACK_DATA;

        [SerializeField] private float m_Blend;
        [SerializeField] private float m_Timer;

        public override void InitComponent()
        {
            SetupBodyParts();
        }

        public override void OnFixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void OnUpdate()
        {
            switch (_ragdollData.RagdollStateEnum)
            {
                case RagdollStateEnum.Animated:
                    {
                        if (_ragdollData.IsRagdoll)
                        {                            
                            _ragdollData.RagdollStateEnum = RagdollStateEnum.HitReaction;
                        }

                        break;
                    }
                case RagdollStateEnum.HitReaction:
                    {                        
                        int randomIndex = Random.Range(0, HashTool.GetLenght(typeof(HitReactionStatesEnum)));                        
                        
                        control.ANIMATOR.Play(
                            HashManager.Instance.DicHitReaction[(HitReactionStatesEnum)randomIndex],
                            0,
                            0f
                        );

                        control.RunFunction(typeof(GetPushedAsRagdool));
                        
                        m_Timer = Timer;
                        _ragdollData.RagdollStateEnum = RagdollStateEnum.RagdollMode;

                        break;
                    }                
                case RagdollStateEnum.RagdollMode:
                    {
                        _attackData.isAttackAble = false;

                        AnimatorStateInfo stateInfo = control.ANIMATOR.GetCurrentAnimatorStateInfo(0);                                                
                        
                        if (!(stateInfo.normalizedTime >= .3))
                        {
                            return;
                        }                        

                        if (control.GetBool(typeof(CharacterDead)))
                        {                            
                            _ragdollData.RagdollStateEnum = RagdollStateEnum.Dead;                            
                        }
                        else
                        {
                            _ragdollData.RagdollStateEnum = RagdollStateEnum.DamageRecover;
                        }

                        ActiveRagdoll(true, true);
                        break;
                    }

                case RagdollStateEnum.DamageRecover:
                    {
                        if (_ragdollData.Hip.Rigidbody.velocity == Vector3.zero)
                        {
                            m_Timer = Mathf.MoveTowards(m_Timer, 0.0f, Time.deltaTime);
                        }                        

                        if (m_Timer == 0.0f)
                        {
                            control.transform.position = _ragdollData.Hip.Transform.position;
                            var euler = _ragdollData.Hip.Transform.rotation.eulerAngles;                            

                            control.transform.rotation = Quaternion.Euler(0f, euler.y, 0f);
                            
                            _ragdollData.RagdollStateEnum = RagdollStateEnum.WaitForStable;
                        }                        

                        break;
                    }
                case RagdollStateEnum.WaitForStable:
                    {                        
                        _ragdollData.Hip.Transform.parent = _ragdollData.HipParent.transform;

                        m_Blend = 1f;

                        _ragdollData.RagdollStateEnum = RagdollStateEnum.RagdollToAnim;
                        
                        GetUp();
                        foreach (var body in _ragdollData.BodyParts)
                        {
                            body.StoredPosition = body.Transform.localPosition;
                            body.StoredRotation = body.Transform.localRotation;
                        }
                        
                        ActiveRagdoll(false, true);
                        break;
                    }
                case RagdollStateEnum.Dead:
                    {                        
                        control.BOX_COLLIDER.enabled = false;

                        control.RIGID_BODY.velocity = Vector3.zero;
                        control.RIGID_BODY.angularVelocity = Vector3.zero;
                        control.RunFunction(typeof(ClearRagdollVelocity));

                        control.gameObject.layer = LayerMask.NameToLayer(GameLayerEnum.DEADBODY.ToString());

                        if (control.aiController != null)
                        {
                            control.aiController = null;
                            control.aIProgress = null;
                            control.gameObject.GetComponent<NavMeshObstacle>().enabled = false;
                        }
                                                
                        _ragdollData.RagdollStateEnum = RagdollStateEnum.None;

                        _ragdollData.Hip.Transform.parent = _ragdollData.HipParent.transform;

                        ActiveRagdoll(false, true);

                        _deadData.Dead = true;
                        break;
                    }
            }
        }

        public override void OnLateUpdate()
        {
            if (_ragdollData.RagdollStateEnum == RagdollStateEnum.RagdollToAnim)
            {
                m_Blend = Mathf.MoveTowards(m_Blend, .0f, Time.unscaledTime);

                foreach (Muscle bodyPart in _ragdollData.BodyParts)
                {
                    bodyPart.Transform.localPosition = Vector3.Slerp(bodyPart.Transform.localPosition, bodyPart.StoredPosition, m_Blend);
                    bodyPart.Transform.localRotation = Quaternion.Slerp(bodyPart.Transform.localRotation, bodyPart.StoredRotation, m_Blend);
                }

                if (m_Blend <= 0)
                {                     
                    _ragdollData.RagdollStateEnum = RagdollStateEnum.Animated;
                    m_Timer = Timer;
                    _ragdollData.IsRagdoll = false;
                    _attackData.isAttackAble = true;
                    control.RIGID_BODY.velocity = Vector3.zero;
                    control.RIGID_BODY.angularVelocity = Vector3.zero;
                    control.RunFunction(typeof(ClearRagdollVelocity));
                }
            }
        }

        public void SetupBodyParts()
        {
            Rigidbody[] rb = control.GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody bodyPart in rb)
            {
                bodyPart.interpolation = RigidbodyInterpolation.Interpolate;
                bodyPart.collisionDetectionMode = CollisionDetectionMode.Continuous;

                if (bodyPart.gameObject != control.gameObject)
                {
                    _ragdollData.BodyParts.Add(new Muscle(bodyPart.gameObject));
                }
            }

            foreach(Muscle m in _ragdollData.BodyParts)
            {
                if (m.Joint == null)
                {
                    _ragdollData.Hip = m;
                }
            }

            _ragdollData.HipParent = _ragdollData.Hip.Transform.parent.transform;
            ActiveRagdoll(false, true);
        }

        public void ActiveRagdoll(bool isActive, bool gravity)
        {
            control.ANIMATOR.enabled = !isActive;

            if (isActive)
            {
                _ragdollData.Hip.Transform.parent = null;
            }

            control.RIGID_BODY.useGravity = gravity;
            control.RIGID_BODY.isKinematic = isActive;
            control.BOX_COLLIDER.isTrigger = isActive;

            foreach (Muscle body in _ragdollData.BodyParts)
            {
                body.Rigidbody.useGravity = gravity;
                body.Rigidbody.isKinematic = !isActive;
                body.Collider.isTrigger = !isActive;                
            }
        }

        private void GetUp()
        {
            control.ANIMATOR.Play( CheckIfLieOnBack() ? 
                HashManager.Instance.DicWakeUp[Wake_Up_States.WakeUpFromBack] : 
                HashManager.Instance.DicWakeUp[Wake_Up_States.WakeUpFromFront]
                , 0, 0);
        }

        bool CheckIfLieOnBack()
        {
            RaycastHit hit;

            if (Physics.Raycast(_ragdollData.Hip.Transform.position, _ragdollData.Hip.Transform.forward, out hit, 1f, LayerMask.GetMask(GameLayerEnum.PLATFORMER.ToString())))
            {
                Debug.DrawLine(_ragdollData.Hip.Transform.position, hit.point, Color.green);
                return false;
            }
            return true;
        }
    }            
}