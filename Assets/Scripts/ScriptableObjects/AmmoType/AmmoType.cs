using UnityEngine;

[CreateAssetMenu(menuName = "Ammo Type")]
public class AmmoType : ScriptableObject
{
    public int ammoCost;
    public int damage;
    public int loadoutIndex;
}
