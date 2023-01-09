using UnityEngine;

[CreateAssetMenu(menuName = "Ammo Type")]
public class AmmoType : ScriptableObject
{
    public Sprite sprite;
    public int ammoCost;
    public int damage;
    public float lifetimeSeconds;
    public int loadoutIndex;
}
