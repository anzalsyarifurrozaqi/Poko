using UnityEngine;

namespace anzal.game
{
    public class Projectile : MonoBehaviour
    {
        public CharacterControl Control;
        public Collider AttackCollider;
        public TriggerDetector triggerDetector;
        
        private Vector3 _shootDir;
        private PoolObject _poolObject;
        [SerializeField] float speed = 0.5f;

        private Rigidbody _rigidBody;
        private bool _isReady= false;
        private void OnEnable()
        {
            AttackCollider = GetComponent<Collider>();
            _poolObject = GetComponent<PoolObject>();
            _rigidBody = GetComponent<Rigidbody>();

            _rigidBody.velocity = Vector3.zero;
        }

        public void RegisterProjectil(CharacterControl control, Vector3 shootDir)
        {
            Control = control;                  
            _shootDir = shootDir;            

            transform.localPosition = control.Weapon.transform.position;
            transform.localRotation = control.Weapon.transform.rotation;

            AttackCollider.enabled = true;
            _isReady = true;
        }

        public void DeRegisterProjectile()
        {
            AttackCollider.enabled = false;
            _shootDir = Vector3.zero;
            _rigidBody.velocity = Vector3.zero;

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            _isReady = false;
        }

        private void FixedUpdate()
        {
            if (!_isReady)
            {
                return;
            }
            
            _rigidBody.velocity = _shootDir * speed * Time.deltaTime;
        }

        private void OnDisable()
        {
            DeRegisterProjectile();
        }
    }
}
