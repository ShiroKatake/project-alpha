using NUnit.Framework;
using ShootSystem;
public class AmmoTests
{
    [Test]
    public void AmmoCountIsInitialized()
    {
        Ammo ammo = new Ammo(5);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void TryConsumeAmmo_AmmoConsumedWhenCostLessThanAmmoCount()
    {
        Ammo ammo = new Ammo(5);
        ammo.TryConsumeAmmo(1);
        Assert.AreEqual(4, ammo.CurrentAmmoCount);
    }

    [Test]
    public void TryConsumeAmmo_AmmoNotConsumedWhenCostGreaterThanAmmoCount()
    {
        Ammo ammo = new Ammo(5);
        ammo.TryConsumeAmmo(6);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void RefillAmmo_AmmoIsRefilled()
    {
        Ammo ammo = new Ammo(5);
        ammo.TryConsumeAmmo(2);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(4, ammo.CurrentAmmoCount);
    }

    [Test]
    public void RefillAmmo_AmmoDoesNotExceedCapacityDuringRefill()
    {
        Ammo ammo = new Ammo(5);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_CapacityIsIncreased()
    {
        Ammo ammo = new Ammo(5);
        ammo.AddAmmoCapacity(1);
        ammo.RefillAmmo(1f);
        Assert.AreEqual(6, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_CapacityIsIncreasedButCurrentCountDoesNot()
    {
        Ammo ammo = new Ammo(5);
        ammo.AddAmmoCapacity(1);
        Assert.AreEqual(5, ammo.CurrentAmmoCount);
    }

    [Test]
    public void AddAmmoCapacity_EventIsRaised()
    {
        Ammo ammo = new Ammo(5);
        bool eventIsRaised = false;

        ammo.OnAmmoCapcityUpdate += () => eventIsRaised = true;
        ammo.AddAmmoCapacity(1);
        Assert.IsTrue(eventIsRaised);
    }
}
