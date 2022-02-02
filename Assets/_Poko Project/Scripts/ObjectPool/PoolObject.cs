using System.Collections;
using UnityEngine;

namespace anzal.game
{
    public class PoolObject : MonoBehaviour
    {
        public PoolObjectTypeEnum PoolObjectType;
        public float ScheduledOffTime;
        [System.NonSerialized] public PoolObject Next = null;
        
        private Coroutine OffRoutine;        

        private void OnEnable() 
        {
            if (OffRoutine != null)
            {
                StopCoroutine(OffRoutine);
            }

            if (ScheduledOffTime > 0f)
            {
                OffRoutine = StartCoroutine(_ScheduleOffOnTime());
            }
        }

        public void TurnOff()
        {
            ObjectPoolManager.Instance.ConfigureDeactivatedObject(this);

            gameObject.SetActive(false);            
        }

        IEnumerator _ScheduleOffOnTime()
        {
            yield return new WaitForSeconds(ScheduledOffTime);

            if (ObjectPoolManager.Instance.PoolDictionary.ContainsKey(PoolObjectType))
            {
                if (ObjectPoolManager.Instance.PoolDictionary[PoolObjectType].Contains(this))
                {                    
                    TurnOff();
                }
            }
        }
    }
}
