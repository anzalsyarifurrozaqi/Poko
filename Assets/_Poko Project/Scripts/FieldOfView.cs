using System.Collections;
using UnityEngine;

namespace anzal.game
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewRadius;
        //[Range(0, 360)]
        //public float viewAngle;

        public LayerMask EnemyMask;
        public LayerMask EnvironmentMask;

        //public List<Transform> visibleEnemys = new List<Transform>();

        public Datasets DATASETS
        {
            get
            {
                return _datasets;
            }
        }
        private Datasets _datasets;
                
        private void Awake()
        {
            _datasets = GetComponent<Datasets>();
        }
        private void Start()
        {            
            StartCoroutine("FindTargetWithDelay", 1f * Time.deltaTime);
        }

        IEnumerator FindTargetWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTarget();
            }
        }

        void FindVisibleTarget()
        {
            _datasets.ENEMY_DATA.visibleEnemys.Clear();
            Collider[] enemyInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, EnemyMask);

            for (int i = 0; i < enemyInViewRadius.Length; i++)
            {                
                if (enemyInViewRadius[i].transform != this.transform)
                {
                    Transform enemy = enemyInViewRadius[i].transform;
                    //Vector3 dirToEnemy = (enemy.position - transform.position).normalized;
                    if (Vector3.Distance (transform.position, enemy.position) < viewRadius)
                    {                    
                        float disToEnemy = Vector3.Distance(transform.position, enemy.position);

                        if (!Physics.Raycast (transform.position, enemy.position, disToEnemy, EnvironmentMask))
                        {                        
                            _datasets.ENEMY_DATA.visibleEnemys.Add(enemy.root.GetComponent<CharacterControl>());
                        }
                    }
                }                
            }
        }

        //public Vector3 DirFromAngle(float angleDegrees, bool angleIsGlobal)
        //{
        //    if (!angleIsGlobal)
        //    {
        //        angleDegrees += transform.eulerAngles.y;
        //    }

        //    return new Vector3(Mathf.Sin(angleDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleDegrees * Mathf.Deg2Rad));
        //}
    }
}
