using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IDamageable, ITalkable
{
    public static readonly string PrefabPath = "Prefab/Enemy";

    public void Damage(int damage)
    {
        if (IsDead) return;

        Hp -= damage;
        Debug.Log(Name + "は" + damage + "をうけた！");

        if (IsDead)
        {
            Hp = 0;
            Debug.Log(Name + "はおとなしくなった");
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (IsDead) return;

        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.Damage(Power);
    }
}
