using UnityEngine;

namespace Assets.Scripts
{
    public class ItemSpawner : MonoBehaviour
    {

        [SerializeField] private GameObject _prefab;
       
        [SerializeField] private Vector3 _range;

        public int _count;


        void Start()
        {
            int _count = Random.Range(3, 3);    
            for (int i = 0; i < _count; i++)
            {  
                Vector3 offset = new Vector3(Random.Range(-_range.x, _range.x), Random.Range(-_range.y, _range.y), Random.Range(-_range.z, _range.z));
                var obj = Instantiate(_prefab, transform.position + offset, Quaternion.identity);
                obj.transform.parent = transform;
            }
        }
    }
}