using UnityEngine;
using UnityEngine.AI;

namespace anzal.game
{
    [CreateAssetMenu(fileName = "New State", menuName = "AnzalGame/AI/SendPathFindingAgent")]
    public class SendPathFindingAgent : CharacterAbility
    {                
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            Vector3 navMeshPosition = characterState.control.DATASET.GROUND_DATA.NavMeshPosition;           

            if (characterState.control.aIProgress.pathFindingAgent == null)
            {
                GameObject p = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.PATH_FINDING_AGENT);
                p.SetActive(true);
                
                characterState.control.aIProgress.pathFindingAgent = p.GetComponent<PathFindingAgent>();
            }

            characterState.control.aIProgress.pathFindingAgent.owner = characterState.control;
            characterState.control.aIProgress.pathFindingAgent.GetComponent<NavMeshAgent>().enabled = false;

            characterState.control.aIProgress.pathFindingAgent.transform.position = navMeshPosition;

            characterState.control.navMeshObstacle.carving = false;
            characterState.control.aIProgress.pathFindingAgent.GotoTarget();
        }       

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {            
            if (characterState.control.aIProgress.pathFindingAgent.StartWalk)
            {
                animator.SetBool(HashManager.Instance.ArrAITransition[(int)AITransitionEnum.Walk], true);
            }            
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(HashManager.Instance.ArrAITransition[(int)AITransitionEnum.Walk], false);
        }
    }
}