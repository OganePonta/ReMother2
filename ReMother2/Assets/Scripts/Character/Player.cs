using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IDamageable, IParty
{
    public static readonly string PrefabPath = "Prefabs/Player";

    private const float MoveBuff = 0.03f;

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        var movement = new Vector3(h * MoveBuff, v * MoveBuff, 0);

        if (movement != Vector3.zero)
            Move(movement);
    }

    public void Damage(int damage)
    {
        if (IsDead) return;

        Hp -= damage;
        Debug.Log(Name + "は" + damage + "をうけた！");

        if(IsDead)
        {
            Hp = 0;
            Debug.Log(Name + "は、ちからつきた...");
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (IsDead) return;

        var talkable = other.GetComponent<ITalkable>();
        if (talkable != null && !(talkable is IParty))
            talkable.Talk();

        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null & !(damageable is IParty))
            damageable.Damage(Power);
    }

    private void Move(Vector3 movement)
    {
        transform.localPosition += movement;
    }
}
