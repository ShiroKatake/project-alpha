using NUnit.Framework;
using UnityEngine.TestTools;
using HealthSystem;

public class HealthTests
{
    [Test]
    public void HealthAndMaxHealthIsSet()
    {
        Health health = new Health(10);
        Assert.AreEqual(10, health.CurrentHealth);
        Assert.AreEqual(10, health.MaxHealth);
    }

    [Test]
    public void TakeDamage_HealthIsLost()
    {
        Health health = new Health(10);

        health.TakeDamage(1);
        Assert.AreEqual(10, health.MaxHealth);
        Assert.AreEqual(9, health.CurrentHealth);
    }

    [Test]
    public void TakeDamage_HealthDoesDecreaseBelowZero()
    {
        Health health = new Health(1);

        health.TakeDamage(2);
        Assert.AreEqual(0, health.CurrentHealth);
    }

    [Test]
    public void TakeDamage_EventIsRaised()
    {
        Health health = new Health(10);
        bool damageTakenEventHasBeenRaised = false;
        bool deathEventHasBeenRaised = false;
        health.OnDamageTaken += (amount) => { damageTakenEventHasBeenRaised = true; };
        health.OnDeath += () => { deathEventHasBeenRaised = true; };

        health.TakeDamage(1);
        Assert.IsTrue(damageTakenEventHasBeenRaised);
        Assert.IsFalse(deathEventHasBeenRaised);
    }

    [Test]
    public void HealthReachesZero_EventIsRaised()
    {
        Health health = new Health(1);
        bool damageTakenEventHasBeenRaised = false;
        bool deathEventHasBeenRaised = false;
        health.OnDamageTaken += (amount) => { damageTakenEventHasBeenRaised = true; };
        health.OnDeath += () => { deathEventHasBeenRaised = true; };

        health.TakeDamage(1);
        Assert.IsTrue(damageTakenEventHasBeenRaised);
        Assert.IsTrue(deathEventHasBeenRaised);
    }

    [Test]
    public void HealthReachesZero_CannotTakeDamage()
    {
        Health health = new Health(0);
        bool damageTakenEventHasBeenRaised = false;
        bool deathEventHasBeenRaised = false;
        health.OnDamageTaken += (amount) => { damageTakenEventHasBeenRaised = true; };
        health.OnDeath += () => { deathEventHasBeenRaised = true; };

        health.TakeDamage(1);
        Assert.IsFalse(damageTakenEventHasBeenRaised);
        Assert.IsFalse(deathEventHasBeenRaised);
    }

    [Test]
    public void Heal_HealthIsGained()
    {
        Health health = new Health(10);
        health.TakeDamage(2);

        health.Heal(1);
        Assert.AreEqual(10, health.MaxHealth);
        Assert.AreEqual(9, health.CurrentHealth);
    }

    [Test]
    public void Heal_HealthDoesNotIncreaseAboveMaxHealth()
    {
        Health health = new Health(10);

        health.Heal(1);
        Assert.AreEqual(10, health.CurrentHealth);
    }

    [Test]
    public void Heal_EventIsRaised()
    {
        Health health = new Health(10);
        bool eventHasBeenRaised = false;
        health.OnHealthGained += (amount) => { eventHasBeenRaised = true; };

        health.Heal(1);
        Assert.IsTrue(eventHasBeenRaised);
    }

    [Test]
    public void IncreaseMaxHealth_MaxHealthIsIncreased()
    {
        Health health = new Health(10);

        health.IncreaseMaxHealth(1);
        Assert.AreEqual(11, health.MaxHealth);
    }
}
