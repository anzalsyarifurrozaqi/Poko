using UnityEngine;

namespace anzal.game
{
    public class TriggerDetector : MonoBehaviour
    {
        public CharacterControl Control;
        public Collider triggerCollider;
        public Rigidbody body;

        private void Awake()
        {
            Control = GetComponentInParent<CharacterControl>();
            triggerCollider = GetComponent<Collider>();
            body = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider col)
        {            
            CharacterControl attacker = CheckCollidingBodyPart(col);
            Projectile projectile = CheckCollidingProjectile(col);
            
            if (attacker != null || projectile != null)
            {
                Control.RunFunction(typeof(AddHitObject), col, this);
            }
            //if (attacker != null)
            //{
            //    Debug.Log($"{gameObject.transform.root.name} : {attacker.gameObject.name}");
            //}

            //if (projectile != null)
            //{
            //    Debug.Log($"{gameObject.transform.root.name} : {projectile.gameObject.name}");
            //}
        }

        private void OnTriggerExit(Collider col)
        {
            Control.RunFunction(typeof(RemoveHitObj), col, this);
        }

        CharacterControl CheckCollidingBodyPart(Collider col)
        {

            foreach (Muscle bodyPart in Control.DATASET.RAGDOLL_DATA.BodyParts)
            {
                if (bodyPart.Collider == col)
                {
                    return null;
                }
            }

            CharacterControl control = col.GetComponentInParent<CharacterControl>();

            if (control == null)
            {                
                return null;
            }

            if (control == Control)
            {
                return null;
            }                       

            if (control.gameObject.layer == Control.gameObject.layer)
            {
                return null;
            }

            if (control.gameObject.layer == LayerMask.NameToLayer(GameLayerEnum.DEADBODY.ToString()))
            {
                return null;
            }
           
            return control;
        }

        Projectile CheckCollidingProjectile(Collider col)
        {
            Projectile projectile = col.GetComponent<Projectile>();

            if (projectile == null)
            {                
                return null;
            }

            if (Control == projectile.Control)
            {                
                return null;
            }

            return projectile;
        }
    }
}