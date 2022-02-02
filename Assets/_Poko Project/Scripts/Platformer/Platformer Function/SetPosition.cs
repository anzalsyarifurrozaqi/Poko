using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace anzal.game
{
    public class SetPosition : PlatformerFunction
    {        
        private float _moveDuration = 0.5f;
        private BoxCollider _boxColliderNewPlatformer;
        private BoxCollider _boxColliderCurrentPlatformer;
        private Vector3 _targetPosition;
        private Vector3 _offsetPosition = new Vector3(0.0f, 5.0f, 0.0f);
        private List<TriggerArea> _triggerAreaList = new List<TriggerArea>();        
        public override void RunFunction(TriggerAreaPositionEnum triggerAreaPosition, PlatformerControl platformer, PlatformerControl newPlatformer)
        {
            _boxColliderCurrentPlatformer = platformer.BOX_COLLIDER;
            _boxColliderNewPlatformer = newPlatformer.BOX_COLLIDER;
            _triggerAreaList.AddRange(newPlatformer.DATASET.PLATFORMER_TRIGGER_DATA.TriggerAreaList);

            switch (triggerAreaPosition)
            {
                case TriggerAreaPositionEnum.RIGHT:
                    {
                        GameObject triggerAreaLeft = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.LEFT).gameObject;
                        triggerAreaLeft.SetActive(false);

                        var rightSidePlatformer = _boxColliderCurrentPlatformer.bounds.center.z + (_boxColliderCurrentPlatformer.bounds.size.z / 2f);
                        var offset = _boxColliderNewPlatformer.bounds.size.z / 2f;

                        _targetPosition = new Vector3(platformer.transform.position.x, platformer.transform.position.y, rightSidePlatformer + offset);

                        PlatformerManager.Instance.PlatformerIndexPosition.x++;
                        break;
                    }
                case TriggerAreaPositionEnum.LEFT:
                    {
                        GameObject triggerAreaRight = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.RIGHT).gameObject;
                        triggerAreaRight.SetActive(false);

                        var leftSidePlatformer = _boxColliderCurrentPlatformer.bounds.center.z - (_boxColliderCurrentPlatformer.bounds.size.z / 2f);
                        var offset = _boxColliderNewPlatformer.bounds.size.z / 2f;

                        _targetPosition = new Vector3(platformer.transform.position.x, platformer.transform.position.y, leftSidePlatformer - offset);

                        PlatformerManager.Instance.PlatformerIndexPosition.x--;
                        break;
                    }
                case TriggerAreaPositionEnum.TOP:
                    {
                        GameObject triggerAreaBottom = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.BOTTOM).gameObject;
                        triggerAreaBottom.SetActive(false);

                        var frontSidePlatformer = _boxColliderCurrentPlatformer.bounds.center.x - (_boxColliderCurrentPlatformer.bounds.size.x / 2f);
                        var offset = _boxColliderNewPlatformer.bounds.size.x / 2f;

                        _targetPosition = new Vector3(frontSidePlatformer - offset, platformer.transform.position.y, platformer.transform.position.z);

                        PlatformerManager.Instance.PlatformerIndexPosition.y++;
                        break;
                    }
                case TriggerAreaPositionEnum.BOTTOM:
                    {
                        GameObject triggerAreaTop = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.TOP).gameObject;
                        triggerAreaTop.SetActive(false);

                        var bottomSidePlatformer = _boxColliderCurrentPlatformer.bounds.center.x + (_boxColliderCurrentPlatformer.bounds.size.x / 2f);
                        var offset = _boxColliderNewPlatformer.bounds.size.x / 2f;

                        _targetPosition = new Vector3(bottomSidePlatformer + offset, platformer.transform.position.y, platformer.transform.position.z);

                        PlatformerManager.Instance.PlatformerIndexPosition.y--;
                        break;
                    }
                case TriggerAreaPositionEnum.NULL:
                    {
                        _targetPosition = Vector3.zero;
                        break;
                    }
            } 

            if (PlatformerManager.Instance.PlatformerIndexPosition.x > 2)
            {
                GameObject triggerAreaRight = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.RIGHT).gameObject;
                triggerAreaRight.SetActive(false);
            } 
            else if (PlatformerManager.Instance.PlatformerIndexPosition.x < -2)
            {
                GameObject triggerAreaLeft = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.LEFT).gameObject;
                triggerAreaLeft.SetActive(false);
            }

            if (PlatformerManager.Instance.PlatformerIndexPosition.y > 2)
            {
                GameObject triggerAreaTop = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.TOP).gameObject;
                triggerAreaTop.SetActive(false);
            }
            else if (PlatformerManager.Instance.PlatformerIndexPosition.y < -2)
            {
                GameObject triggerAreaBottom = _triggerAreaList.Find((t) => t.TriggerAreaPosition == TriggerAreaPositionEnum.BOTTOM).gameObject;
                triggerAreaBottom.SetActive(false);
            }

            StartCoroutine(SetNewPlatformerPosition(
                    newPlatformer,
                    _targetPosition
                ));            
        }

        IEnumerator SetNewPlatformerPosition(PlatformerControl platformer, Vector3 targetPosition)
        {
            yield return new WaitForEndOfFrame();
            float time = 0.0f;            

            Vector3 startPlatformerPosition = targetPosition - _offsetPosition;            

            while (time < _moveDuration)
            {
                platformer.transform.position = Vector3.Lerp(startPlatformerPosition, targetPosition, time / _moveDuration);

                time += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }

            platformer.transform.position = targetPosition;
        }
    }
}
