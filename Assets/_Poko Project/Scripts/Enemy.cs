using UnityEngine;

namespace anzal.game
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CharacterControl _enemy;

        private void OnEnable()
        {
            _enemy = GetComponent<CharacterControl>();

            InitCharacterStates(_enemy.ANIMATOR);

            if (_enemy.DATASET.FALLEN_DATA.Fallen)
            {
                _enemy.RunFunction(typeof(ReInitCharacter));
            }
        }

        void InitCharacterStates(Animator animator)
        {            
            CharacterState[] characterStates = animator.GetBehaviours<CharacterState>();

            foreach (CharacterState c in characterStates)
            {
                c.control = _enemy;
            }
        }
    }
}