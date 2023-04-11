using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Agava.IdleGame.Model;

namespace Agava.IdleGame
{
    public class BoxStackView : StackView
    {
        [Space(15f)]
        [SerializeField] private Vector3Int _size = Vector3Int.one;
        [SerializeField] private Vector3 _distanceBetweenObjects = Vector3.one;

#if UNITY_EDITOR
        [Space(5)]
        [SerializeField] private bool _drawGizmos;

        private void OnDrawGizmos()
        {
            if (_drawGizmos == false)
                return;

            Gizmos.color = Color.red;

            for (int y = 0; y < _size.y; y++)
            {
                for (int x = 0; x < _size.x; x++)
                {
                    for (int z = 0; z < _size.z; z++)
                    {
                        var position = transform.TransformPoint(
                            new Vector3(x * _distanceBetweenObjects.x, y * _distanceBetweenObjects.y, z * _distanceBetweenObjects.z));

                        Gizmos.DrawSphere(position, 0.2f);
                    }
                }
            }
        }
#endif

        protected override Vector3 CalculateAddEndPosition(Transform container, Transform stackable)
        {
            var index = container.childCount;

            return Vector3.Scale(PositionByIndex(index), _distanceBetweenObjects);
        }

        protected override void Sort(IEnumerable<StackableObject> unsortedStackables, float animationDuration)
        {
            int index = 0;
            foreach (var stackable in unsortedStackables)
            {
                var position = Vector3.Scale(PositionByIndex(index), _distanceBetweenObjects);

                stackable.View.DOComplete(true);
                stackable.View.DOLocalMove(position, animationDuration);

                index++;
            }
        }

        private Vector3 PositionByIndex(int index)
        {
            var x = index % _size.x;
            var y = index / (_size.x * _size.z);
            var z = (index / _size.x) % _size.z;

            return new Vector3(x, y, z);
        }
    }
}