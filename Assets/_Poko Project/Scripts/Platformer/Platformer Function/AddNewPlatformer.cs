using UnityEngine;

namespace anzal.game
{
    public class AddNewPlatformer : PlatformerQuery
    {        
        public override PlatformerControl GetPlatformer()
        {
            GameObject newPlatformer = ObjectPoolManager.Instance.GetObject(PoolObjectTypeEnum.GROUND);

            newPlatformer.gameObject.SetActive(true);

            if (!PlatformerManager.Instance.ListPlatformer.Contains(newPlatformer.GetComponent<PlatformerControl>()))
            {
                PlatformerManager.Instance.ListPlatformer.Add(newPlatformer.GetComponent<PlatformerControl>());
            }

            if (PlatformerManager.Instance.ListPlatformer.Count > 2)
            {                
                GameManager.Instance.RemovePlatformerInvoke();
            }            
            
            return newPlatformer.GetComponent<PlatformerControl>();
        }
    }
}