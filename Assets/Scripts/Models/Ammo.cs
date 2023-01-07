using UnityEngine;

namespace ShootSystem
{
    public class Ammo
    {
        private int _ammoCost;

        public int AmmoCost { get => _ammoCost; }
        public int LoadoutIndex { get; set; } = -1;

        public Ammo(int ammoCost)
        {
            _ammoCost = ammoCost;
        }
    }
}
