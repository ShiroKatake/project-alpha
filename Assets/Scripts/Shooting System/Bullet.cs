using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Collider2D hitbox;
	[SerializeField] private int _ammoCost;

    public int AmmoCost { get => _ammoCost; }

    public Bullet(int ammoCost)
	{
        _ammoCost = ammoCost;
    }
}