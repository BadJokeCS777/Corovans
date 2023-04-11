using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class HorizontalStackView : StackView
    {
        [SerializeField] private float _space = 0.05f;
        
#if UNITY_EDITOR
        [Header("Gizmos")]
        [SerializeField] private bool _drawGizmos;
        [SerializeField, Range(1, 5)] private int _drawCount = 1;
        [SerializeField, Range(0.1f, 1f)] private float _drawSphereRadius = 0.5f;

        private void OnDrawGizmos()
        {
            if (_drawGizmos == false)
                return;

            Gizmos.color = Color.red;

            for (int i = 0; i < _drawCount; i++)
            {
                var position = transform.TransformPoint(Vector3.right * i * ( _space + _drawSphereRadius * 2));
                Gizmos.DrawSphere(position, _drawSphereRadius);
            }
        }
#endif

        protected override Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
        {
            return Vector3.right * container.childCount * (stackable.lossyScale.x + _space);
        }

        protected override void Sort(IEnumerable<StackableObject> unsortedStackables, float animationDuration)
        {
            var sortedList = unsortedStackables.OrderBy(stackable => stackable.View.localPosition.x);

            var iteration = 0;
            foreach (var item in sortedList)
            {
                var position = Vector3.right * iteration * (item.View.lossyScale.x + _space);

                item.View.DOComplete(true);
                item.View.DOLocalMove(position, animationDuration);

                iteration++;
            }
        }
    }
}