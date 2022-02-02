using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace anzal.game
{
    public class GameManager : Singleton<GameManager>, IPauseHandler, IAddEnemy, IRemovePlatformer
    {        
        static PauseEvent pauseEvent = new PauseEvent();
        static AddEnemyEvent addEnemyEvent = new AddEnemyEvent();
        static RemovePlatformerEvent removePlatformerEvent = new RemovePlatformerEvent();

        public Image GameOverPanel;        
        public CharacterControl Player;
        public int GameSpeed = 1;

        private bool _isGameOver = false;

#region PRIVATE METHOD
        private void Awake() 
        {
            EventManager.Instance.AddEnemyInvoker(this);
            EventManager.Instance.AddRemovePlatformerInvoker(this);
        }
        private void Update()
        {
            if (!_isGameOver && Player.DATASET.DEAD_DATA.Dead)
            {
                GameOver();
            }            
        }
#endregion

#region PUBLIC METHOD
        public void InitEvent()
        {            
            EventManager.Instance.AddPauseInvoker(this);
        }

        public void InitPlatformer()
        {
            GameObject platformer = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.GROUND);
            platformer.SetActive(true);
            platformer.transform.position = Vector3.zero;

            PlatformerManager.Instance.ListPlatformer.Add(platformer.GetComponent<PlatformerControl>());
        }
#endregion

#region UTIL METHOD
        void GameOver()
        {
            _isGameOver = true;
            GameOverPanel.gameObject.SetActive(true);
            pauseEvent.Invoke(true);
        }
#endregion

#region  Listener
        public void AddCharacterPausedListener(UnityAction<bool> listener)
        {
            pauseEvent.AddListener(listener);
        }

        public void AddEnemyListener(UnityAction listener)
        {
            addEnemyEvent.AddListener(listener);
        }

        public void RemovePlatformerListener(UnityAction listener)
        {
            removePlatformerEvent.AddListener(listener);
        }        
#endregion

#region  Invoker
        public void AddEnemyInvoker()
        {            
            addEnemyEvent.Invoke();
        }        

        public void RemovePlatformerInvoke()
        {            
            removePlatformerEvent.Invoke();
        }
#endregion
    }   
}