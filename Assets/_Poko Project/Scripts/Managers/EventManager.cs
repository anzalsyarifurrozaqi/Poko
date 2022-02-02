using System.Collections.Generic;
using UnityEngine.Events;

namespace anzal.game
{
    public class EventManager : Singleton<EventManager>
    {
        static List<IPauseHandler> _pauseInvoker = new List<IPauseHandler>();
        static List<IRemovePlatformer> _removePlatformerInvoker = new List<IRemovePlatformer>();
        static List<IAddEnemy> _addEnemyInvoker = new List<IAddEnemy>();

        static List<UnityAction<bool>> _pauseListener = new List<UnityAction<bool>>();
        static List<UnityAction> _removePlatformerListener = new List<UnityAction>();
        static List<UnityAction> _addEnemyListener = new List<UnityAction>();

        public void AddPauseInvoker(IPauseHandler invoker)
        {
            foreach (UnityAction<bool> listener in _pauseListener)
            {
                invoker.AddCharacterPausedListener(listener);
            }

            _pauseInvoker.Add(invoker);
        }

        public void addPauseListener(UnityAction<bool> listener)
        {
            foreach (IPauseHandler invoker in _pauseInvoker)
            {
                invoker.AddCharacterPausedListener(listener);
            }

            _pauseListener.Add(listener);
        }

        public void AddRemovePlatformerInvoker(IRemovePlatformer invoker)
        {
            foreach (UnityAction listener in _removePlatformerListener)
            {
                invoker.RemovePlatformerListener(listener);
            }

            _removePlatformerInvoker.Add(invoker);
        }

        public void AddRemovePlatformerListener(UnityAction listener)
        {
            foreach (IRemovePlatformer invoker in _removePlatformerInvoker)
            {
                invoker.RemovePlatformerListener(listener);
            }

            _removePlatformerListener.Add(listener);
        }

        public void AddEnemyInvoker (IAddEnemy invoker)
        {
            foreach (UnityAction listener in _addEnemyListener)
            {
                invoker.AddEnemyListener(listener);
            }

            _addEnemyInvoker.Add(invoker);
        }

        public void AddEnemyListener(UnityAction listener)
        {
            foreach (IAddEnemy invoker in _addEnemyInvoker)
            {
                invoker.AddEnemyListener(listener);
            }

            _addEnemyListener.Add(listener);
        }
    }
}