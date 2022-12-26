using UnityEngine;

namespace ShootSystem
{
    public class Bullet
    {
        private int _ammoCost;

        public int AmmoCost { get => _ammoCost; }
        public int LoadoutIndex { get; set; } = -1;

        public Bullet(int ammoCost)
        {
            _ammoCost = ammoCost;
        }
    }
}
