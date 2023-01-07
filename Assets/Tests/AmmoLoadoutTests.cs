using NUnit.Framework;
using ShootSystem;

public class AmmoLoadoutTests
{
    [Test]
    public void GetAmmoFromEmptyLoadout_WillReturnNull()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();

        Ammo fetchedAmmo = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(null, fetchedAmmo);
    }

    [Test]
    public void GetAmmoOutOfRange_WillReturnNull()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        Ammo ammo = new Ammo(1);
        ammoLoadout.AddAmmoToLoadout(1, ammo);

        Ammo fetchedAmmo0 = ammoLoadout.GetAmmo(0);
        Ammo fetchedAmmo2 = ammoLoadout.GetAmmo(2);
        Assert.AreEqual(null, fetchedAmmo0);
        Assert.AreEqual(null, fetchedAmmo2);
    }

    [Test]
    public void AddAmmoToLoadout_AmmoIsAddedToLoadout()
    {
        Ammo ammo = new Ammo(1);
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammo);

        Ammo fetchedAmmo = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(ammo, fetchedAmmo);
    }

    [Test]
    public void AddAmmoToLoadout_WillNotAddNullAmmo()
    {
        Ammo ammo = null;
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammo);

        Ammo fetchedAmmo = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(null, fetchedAmmo);
    }

    [Test]
    public void AddAmmoToInNewSpot_AmmoIsAddedToNewSpot()
    {
        Ammo ammo = new Ammo(1);
        AmmoLoadout ammoLoadout = new AmmoLoadout(ammo);
        ammoLoadout.AddAmmoToLoadout(1, ammo);

        Ammo fetchedAmmoOldSpot = ammoLoadout.GetAmmo(0);
        Ammo fetchedAmmoNewSpot = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(null, fetchedAmmoOldSpot);
        Assert.AreEqual(ammo, fetchedAmmoNewSpot);
    }

    [Test]
    public void AddNewAmmoToExistingSpot_OldAmmoIsReplacedByNewAmmo()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        Ammo ammo1 = new Ammo(1);
        Ammo ammo2 = new Ammo(2);
        ammoLoadout.AddAmmoToLoadout(1, ammo1);
        ammoLoadout.AddAmmoToLoadout(1, ammo2);

        Ammo fetchedAmmo = ammoLoadout.GetAmmo(1);
        Assert.AreEqual(ammo2, fetchedAmmo);
    }

    [Test]
    public void RemoveAmmoFromEmptySlot_WillSkip()
    {
        AmmoLoadout ammoLoadout = new AmmoLoadout();
        Ammo ammo = new Ammo(1);
        ammoLoadout.AddAmmoToLoadout(0, ammo);
        ammoLoadout.RemoveAmmoFromLoadout(1);

        Ammo fetchedAmmo = ammoLoadout.GetAmmo(0);
        Assert.AreEqual(ammo, fetchedAmmo);
    }
}
