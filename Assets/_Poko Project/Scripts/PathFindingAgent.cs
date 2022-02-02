using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace anzal.game
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PathFindingAgent : MonoBehaviour
    {
        public bool TargetPlaybleCharacter;
        public CharacterControl Target;
        NavMeshAgent navMeshAgent;
        Coroutine MoveRoutine;
        public bool StartWalk;

        public CharacterControl owner = null;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void GotoTarget()
        {            
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = false;
            StartWalk = false;

            if (TargetPlaybleCharacter)
            {
                CharacterControl player = CharacterManager.Instance.GetPlayableCharacter();
                if (player != null)
                {
                    Target = player;
                }                
            }            

            navMeshAgent.SetDestination(Target.transform.position);

            if (MoveRoutine != null)
            {
                StopCoroutine(_Move());
            }

            MoveRoutine = StartCoroutine(_Move());
        }

        private void OnEnable()
        {
            if (MoveRoutine != null)
            {
                StopCoroutine(_Move());
            }
        }

        IEnumerator _Move()
        {
            while (true)
            {
                Vector3 dist = transform.position - navMeshAgent.destination;

                if (Vector3.SqrMagnitude(dist) < 1f)
                {
                    navMeshAgent.isStopped = true;
                    StartWalk = true;
                    yield break;
                }

                yield return new WaitForEndOfFrame();
            }
        }
    }
}

//while (true)
//{
//    if (navMeshAgent.isOnOffMeshLink)
//    {
//        navMeshAgent.CompleteOffMeshLink();
//        navMeshAgent.isStopped = true;
//        StartWalk = true;
//        yield break;
//    }

//    Vector3 dist = transform.position - navMeshAgent.destination;
//    if (Vector3.SqrMagnitude(dist) <= 1f)
//    {
//        navMeshAgent.isStopped = true;
//        StartWalk = true;
//        yield break;
//    }
//    yield return new WaitForEndOfFrame();
//}

//yield return new WaitForSeconds(.5f);
//owner.navMeshObstacle.carving = true;