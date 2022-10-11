using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class DragItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public ItemType Type { get => _type; }
        public UnityEvent OnHideRequest;
        public bool isDraggable { get; private set; }

        [SerializeField] private ItemType _type;

        private Rigidbody _rigidbody;

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

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 position = new Vector3(x, y, 0f);

            _rigidbody.MovePosition(pos);
                      
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
