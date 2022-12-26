using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootSystem
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private Collider2D hitbox;
        [SerializeField] private int _ammoCost;

        private Bullet bullet;
        // Start is called before the first frame update
        void Start()
        {
            bullet = new Bullet(_ammoCost);
        }
    }
}
