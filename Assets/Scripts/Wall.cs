using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private ItemType type;
        [SerializeField] private ItemSpawner _itemSpawner;

        private DragItem _item;
        private Material _material;

        private Color _defaultColor;

        public float _upForce;


        [HideInInspector] public int count = 0;
        private int _count = 1;

        private int _scrore = 0;
        private int _scroreAdd = 1;
        public TMP_Text _textScore;

        public UnityEvent OnWallCalorChange;

        public void SetCount(int value)
        {
            _count = value;

            if (count >= _itemSpawner._count)
            {
                _material.color = Color.grey;
            }
        }


        private void Start() 
        {
            _material = GetComponent<MeshRenderer>().material;  
            _defaultColor = _material.color; 
        }

        private void OnTriggerStay(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (_item = item )
            {
                _material.color = _defaultColor;
                item.GetComponent<Rigidbody>().AddForce(Vector3.down * _upForce );

                if (item.isDraggable == false)
                    TryGetItem();
                
                _item = null;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type == type)
            {
                Destroy(_item.gameObject);
                count++;
                _scrore += _scroreAdd;
                _textScore.text = _scrore.ToString();
                
                if (count >= _itemSpawner._count)
                { 
                    OnWallCalorChange.Invoke();
                    _material.color = Color.grey;
                    Destroy(this);
                }
            }

        }

    }
}