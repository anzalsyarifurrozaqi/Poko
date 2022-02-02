using UnityEngine;

namespace anzal.game
{
    public class HoverMotion : CharacterFunction
    {
        private float _radiusX = 0.5f;
        private float _radiusY = 0.25f;
        private float _radiusZ = 0.5f;

        private float _rateX = 1f;
        private float _rateY = 1f;
        private float _rateZ = 1f;

        private float _offsetX = 0f;
        private float _offsetY = 1f;
        private float _offsetZ = 0f;
        public override void RunFunction(Transform transform, Vector3 basePosition, Quaternion baseRotation)
        {
            Vector3 hover = new Vector3
            (
                _radiusX * Mathf.Sin(_rateX * Time.time + _offsetX),
                _radiusY * Mathf.Sin(_rateY * Time.time + _offsetY),
                _radiusZ * Mathf.Sin(_rateZ * Time.time + _offsetZ)
            );

            transform.localPosition = basePosition + hover;
            transform.localRotation = baseRotation * Quaternion.FromToRotation(Vector3.down, -hover + 3.0f * Vector3.down);
        }
    }
}