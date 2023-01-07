using UnityEngine;

namespace ShootSystem
{
    public class AmmoMagazineBehaviour : MonoBehaviour
    {
        [SerializeField] private int _ammoCapacity;
        [SerializeField] private float _ammoRefillSpeed;

        private AmmoMagazine _ammoMagazine;

        public AmmoMagazine AmmoMagazine { get => _ammoMagazine; }
        // Start is called before the first frame update
        void Awake()
        {
            _ammoMagazine = new AmmoMagazine(_ammoCapacity);
        }

        // Update is called once per frame
        void Update()
        {
            _ammoMagazine.RefillAmmo(_ammoRefillSpeed * Time.deltaTime);
        }
    }
}
