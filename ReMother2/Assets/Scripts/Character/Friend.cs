using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : Character, ITalkable, IDamageable, IParty
{
    public static readonly string PrefabPath = "Prefab/Friend";

    public void Damage(int damage)
    {

    }


    protected override void OnTriggerEnter2D(Collider2D other)
    { 
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !(damageable is IParty))
            damageable.Damage(Power);
    }

}
