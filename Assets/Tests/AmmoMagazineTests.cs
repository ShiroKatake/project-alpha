using NUnit.Framework;
using ShootSystem;
public class AmmoMagazineTests
{
    [Test]
    public void AmmoCountIsInitialized()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void TryConsumeAmmo_AmmoConsumedWhenCostLessThanAmmoCount()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.TryConsumeAmmo(1);
        Assert.AreEqual(4, ammo.CurrentAmmoCount);
    }

    [Test]
    public void TryConsumeAmmo_AmmoNotConsumedWhenCostGreaterThanAmmoCount()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.TryConsumeAmmo(6);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void RefillAmmo_AmmoIsRefilled()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.TryConsumeAmmo(2);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(4, ammo.CurrentAmmoCount);
    }

    [Test]
    public void RefillAmmo_AmmoDoesNotExceedCapacityDuringRefill()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_CapacityIsIncreased()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.AddAmmoCapacity(1);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(6, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_CapacityIsIncreasedButCurrentCountDoesNot()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        ammo.AddAmmoCapacity(1);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_EventIsRaised()
    {
        AmmoMagazine ammo = new AmmoMagazine(5);
        bool eventIsRaised = false;

        ammo.OnAmmoCapcityUpdate += () => eventIsRaised = true;
        ammo.AddAmmoCapacity(1);
        Assert.IsTrue(eventIsRaised);
    }
}
