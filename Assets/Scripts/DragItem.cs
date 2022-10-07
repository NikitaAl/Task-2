using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private ItemType _type;
        public UnityEvent OnHideRequest;

        private Rigidbody _rigidbody;

        public bool isDraggable { get; private set; }

        public ItemType Type { get => _type; }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isDraggable == false)
                return;

            if (!eventData.pointerCurrentRaycast.isValid)
            {
                _rigidbody.isKinematic = false;
                isDraggable = false;

                return;
            }
            var pos = eventData.pointerCurrentRaycast.worldPosition;
            var delta = pos - transform.position;
            delta.z = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rigidbody.isKinematic = true;
            isDraggable = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isDraggable == false)
                return;

            _rigidbody.isKinematic = false;
            isDraggable = false;
        }

    }
}
