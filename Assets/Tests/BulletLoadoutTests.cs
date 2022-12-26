using System.Collections.Generic;
using NUnit.Framework;
using ShootSystem;

public class BulletLoadoutTests
{
    [Test]
    public void GetBulletFromEmptyLoadout_WillReturnNull()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());

        Bullet fetchedBullet = bulletLoadout.GetBullet(0);
        Assert.AreEqual(null, fetchedBullet);
    }

    [Test]
    public void GetBulletOutOfRange_WillReturnNull()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet = new Bullet(1);
        bulletLoadout.AddBulletToLoadout(1, bullet);

        Bullet fetchedBullet0 = bulletLoadout.GetBullet(0);
        Bullet fetchedBullet2 = bulletLoadout.GetBullet(2);
        Assert.AreEqual(null, fetchedBullet0);
        Assert.AreEqual(null, fetchedBullet2);
    }

    [Test]
    public void AddBulletToLoadout_BulletIsAddedToLoadout()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet = new Bullet(1);
        bulletLoadout.AddBulletToLoadout(0, bullet);

        Bullet fetchedBullet = bulletLoadout.GetBullet(0);
        Assert.AreEqual(bullet, fetchedBullet);
    }

    [Test]
    public void AddBulletToLoadout_WillNotAddNullBullet()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet = null;
        bulletLoadout.AddBulletToLoadout(0, bullet);

        Bullet fetchedBullet = bulletLoadout.GetBullet(0);
        Assert.AreEqual(null, fetchedBullet);
    }

    [Test]
    public void AddBulletToInNewSpot_BulletIsAddedToNewSpot()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet = new Bullet(1);
        bulletLoadout.AddBulletToLoadout(0, bullet);
        bulletLoadout.AddBulletToLoadout(1, bullet);

        Bullet fetchedBulletOldSpot = bulletLoadout.GetBullet(0);
        Bullet fetchedBulletNewSpot = bulletLoadout.GetBullet(1);
        Assert.AreEqual(null, fetchedBulletOldSpot);
        Assert.AreEqual(bullet, fetchedBulletNewSpot);
    }

    [Test]
    public void AddNewBulletToExistingSpot_OldBulletIsReplacedByNewBullet()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet1 = new Bullet(1);
        Bullet bullet2 = new Bullet(2);
        bulletLoadout.AddBulletToLoadout(1, bullet1);
        bulletLoadout.AddBulletToLoadout(1, bullet2);

        Bullet fetchedBullet = bulletLoadout.GetBullet(1);
        Assert.AreEqual(bullet2, fetchedBullet);
    }

    [Test]
    public void RemoveBulletFromEmptySlot_WillSkip()
    {
        BulletLoadout bulletLoadout = new BulletLoadout(new Dictionary<int, Bullet>());
        Bullet bullet = new Bullet(1);
        bulletLoadout.AddBulletToLoadout(0, bullet);
        bulletLoadout.RemoveBulletFromLoadout(1);

        Bullet fetchedBullet = bulletLoadout.GetBullet(0);
        Assert.AreEqual(bullet, fetchedBullet);
    }
}
