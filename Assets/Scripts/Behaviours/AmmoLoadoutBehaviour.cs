using UnityEngine;

namespace ShootSystem
{
    public class AmmoLoadoutBehaviour : MonoBehaviour
    {
        [SerializeField] private AmmoType _ammoType1;
        [SerializeField] private AmmoType _ammoType2;
        [SerializeField] private AmmoType _ammoType3;

        private AmmoLoadout _ammoLoadout;

        public AmmoLoadout AmmoLoadout { get => _ammoLoadout; }

        void Awake()
        {
            _ammoLoadout = new AmmoLoadout(_ammoType1, _ammoType2, _ammoType3);
        }
    }
}
