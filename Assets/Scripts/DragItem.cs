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

        private Vector3 _dir;
        private Rigidbody _rigidbody;

        public void Start()
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
            
            _dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var pos = eventData.pointerCurrentRaycast.worldPosition;       
            pos += _dir; 
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
