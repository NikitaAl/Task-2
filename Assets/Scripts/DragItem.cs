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

        private Vector3 _offset;
        private Rigidbody _rigidbody;
        private float _zCoord;
        private float _angularDrag;

        private Vector3 _targetPos;

        const float SPEED_LIMIT = 1000;

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Draggable(bool value)
        {
            _rigidbody.useGravity = !value;
            isDraggable = value;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isDraggable == false)
                return;

            _targetPos = GetMouseWorldPos() + _offset;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Draggable(true);

            _zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            _offset = gameObject.transform.position - GetMouseWorldPos();
            _angularDrag = _rigidbody.angularDrag;
            _rigidbody.angularDrag = 0.8f;

            _targetPos = GetMouseWorldPos() + _offset;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Draggable(false);

            _rigidbody.angularDrag = _angularDrag;
        }

        private Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _zCoord;

            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        private void FixedUpdate()
        {
            if (isDraggable)
            {   
                Vector3 vel = Vector3.Lerp(_rigidbody.velocity, (_targetPos - _rigidbody.position) * 20 , 10 * Time.fixedDeltaTime);
                if (vel.sqrMagnitude > SPEED_LIMIT) 
                {
                    Draggable(false);
                    return;
                }
                _rigidbody.velocity = vel;
            }
        }
    }
}
