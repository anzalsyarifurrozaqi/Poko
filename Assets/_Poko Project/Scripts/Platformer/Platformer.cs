using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class Platformer : MonoBehaviour
    {
        public PlatformerControl PlatformerControl;        
        public List<TriggerArea> ListTriggerArea;                

        private void OnEnable()
        {
            PlatformerControl = GetComponent<PlatformerControl>();

            transform.position = new Vector3(100f, 100f, 100f);
            transform.rotation = Quaternion.identity;            

            PlatformerControl.RIGIDBODY.isKinematic = true;
            PlatformerControl.DATASET.PLATFORMER_TRIGGER_DATA.IsTriggerAreaActive = false;

            foreach (TriggerArea triggerArea in PlatformerControl.DATASET.PLATFORMER_TRIGGER_DATA.TriggerAreaList)
            {
                triggerArea.gameObject.SetActive(true);
            }
        }
    }
}