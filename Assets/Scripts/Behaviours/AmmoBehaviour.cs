using UnityEngine;

namespace ShootSystem
{
    public class AmmoBehaviour : MonoBehaviour
    {
        [SerializeField] private int _ammoCapacity;
        [SerializeField] private float _ammoRefillSpeed;

        private Ammo _ammo;

        public Ammo Ammo { get => _ammo; }
        // Start is called before the first frame update
        void Start()
        {
            _ammo = new Ammo(_ammoCapacity);
        }

        // Update is called once per frame
        void Update()
        {
            _ammo.RefillAmmo(_ammoRefillSpeed * Time.deltaTime);
        }
    }
}
