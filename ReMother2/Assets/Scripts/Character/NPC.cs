using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character, ITalkable
{
    public static readonly string PrefabPath = "Prefab/NPC";
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        //実装しない
    }

}
