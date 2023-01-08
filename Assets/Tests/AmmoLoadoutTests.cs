using NUnit.Framework;
using ShootSystem;
using UnityEngine;

public class AmmoLoadoutTests
{

    [Test]
    public void LoadoutWillInitilize_Empty()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();

        AmmoType fetchedAmmoType = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(null, fetchedAmmoType);
    }

    [Test]
    public void LoadoutWillInitilize_WithAmmoInLoadout()
    {
        AmmoType ammoType1 = ScriptableObject.CreateInstance<AmmoType>();
        AmmoType ammoType2 = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout(null, ammoType1, ammoType2);

        AmmoType fetchedAmmoType1 = ammoLoadout.GetAmmo(1);
        AmmoType fetchedAmmoType2 = ammoLoadout.GetAmmo(2);
        Assert.AreEqual(ammoType1, fetchedAmmoType1);
        Assert.AreEqual(ammoType2, fetchedAmmoType2);
    }

    [Test]
    public void AddAmmoToLoadout_AmmoIsAddedAtDesiredPosition()
    {
        AmmoType ammoType = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        ammoLoadout.AddAmmoToLoadout(10, ammoType);

        AmmoType fetchedAmmoType = ammoLoadout.GetAmmo(10);
        Assert.AreEqual(ammoType, fetchedAmmoType);
    }

    [Test]
    public void AddNullAmmoToLoadout_WillNotAdd()
    {
        AmmoType ammoType = null;
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammoType);

        AmmoType fetchedAmmoType = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(null, fetchedAmmoType);
    }

    [Test]
    public void AddSameAmmoToNewSpot_AmmoIsMovedToNewSpot()
    {
        AmmoType ammoType = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammoType);

        AmmoType fetchedAmmoOldSpot = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(ammoType, fetchedAmmoOldSpot);

        ammoLoadout.AddAmmoToLoadout(1, ammoType);

        fetchedAmmoOldSpot = ammoLoadout.GetAmmo(0);
        AmmoType fetchedAmmoNewSpot = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(null, fetchedAmmoOldSpot);
        Assert.AreEqual(ammoType, fetchedAmmoNewSpot);
    }

    [Test]
    public void AddNewAmmoToExistingSpot_OldAmmoIsReplacedByNewAmmo()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        AmmoType ammoType1 = ScriptableObject.CreateInstance<AmmoType>();
        AmmoType ammoType2 = ScriptableObject.CreateInstance<AmmoType>();

        ammoLoadout.AddAmmoToLoadout(1, ammoType1);
        AmmoType fetchedAmmoType = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(ammoType1, fetchedAmmoType);

        ammoLoadout.AddAmmoToLoadout(1, ammoType2);
        fetchedAmmoType = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(ammoType2, fetchedAmmoType);
    }

    [Test]
    public void GetAmmoOutOfRange_WillReturnNull()
    {
        AmmoType ammoType = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        ammoLoadout.AddAmmoToLoadout(1, ammoType);

        AmmoType fetchedAmmoType0 = ammoLoadout.GetAmmo(0);
        AmmoType fetchedAmmoType1 = ammoLoadout.GetAmmo(1);
        AmmoType fetchedAmmoType2 = ammoLoadout.GetAmmo(2);
        Assert.AreEqual(null, fetchedAmmoType0);
        Assert.AreEqual(ammoType, fetchedAmmoType1);
        Assert.AreEqual(null, fetchedAmmoType2);
    }

    [Test]
    public void RemoveAmmo_AmmoWillBeRemoved()
    {
        AmmoType ammoType = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammoType);
        AmmoType fetchedAmmoType = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(ammoType, fetchedAmmoType);

        ammoLoadout.RemoveAmmoFromLoadout(0);
        fetchedAmmoType = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(null, fetchedAmmoType);
    }

    [Test]
    public void RemoveAmmoFromEmptySlot_WillSkip()
    {
        AmmoType ammoType = ScriptableObject.CreateInstance<AmmoType>();
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammoType);
        ammoLoadout.RemoveAmmoFromLoadout(1);

        AmmoType fetchedAmmoType0 = ammoLoadout.GetAmmo(0);
        AmmoType fetchedAmmoType1 = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(ammoType, fetchedAmmoType0);
        Assert.AreEqual(null, fetchedAmmoType1);
    }
}
