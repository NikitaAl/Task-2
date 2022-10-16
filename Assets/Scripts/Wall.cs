using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Wall : MonoBehaviour
    {
        public Score _Score;
        public UnityEvent _OnWallCalorChange;

        public float _upForce;

        [HideInInspector] public int _count = 0;

        [SerializeField] private ItemType _type;
        [SerializeField] private ItemSpawner _itemSpawner;

        private DragItem _item;
        private Material _material;
        private Color _defaultColor;

        public void SetCount(int value)
        {
            _itemSpawner._count = value;

            if (_count >= _itemSpawner._count)
            {
                _material.color = Color.grey;
            }
        }

        private void Start() 
        {
            _material = GetComponent<MeshRenderer>().material;  
            _defaultColor = _material.color; 
        }

        private void OnTriggerEnter(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();
            
            if (_item = item )
            {
                _material.color = _defaultColor;

                // if (item.isDraggable == true)
                {
                    if ( _item.Type != _type)
                        _item.GetComponent<Rigidbody>().AddForce(Vector3.down * _upForce );  
                    TryGetItem();
                }
                
                _item = null;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type == _type)
            {
                Destroy(_item.gameObject);
                _count++;
                _Score.ScorePanel();

                if (_count >= _itemSpawner._count)
                { 
                    _OnWallCalorChange.Invoke(); 
                    _material.color = Color.grey;
                    Destroy(this);
                }
            }

        }

    }
}