using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private string _charaID = "";

    private SpriteRenderer _renderer;

    public string Name { get; protected set; }
    public string TalkMessage { get; protected set; }

    public int Power { get; protected set; }
    public int Hp { get; protected set; }

    public bool IsDead { get { return Hp <= 0; } }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var master = LoadMaster(_charaID);
        SetDate(master.charaName, master.talkMessage, master.power, master.hp);
        SetSprite(master.charaSprite);
    }

    public virtual void Talk()
    {
        Debug.Log(Name + " 「" + TalkMessage + " 」" );
    }

    protected abstract void OnTriggerEnter2D(Collider2D other);

    private void SetDate(string name, string talkMessage, int power, int hp)
    {
        Name = name;
        TalkMessage = talkMessage;
        Power = power;
        Hp = hp;
    }

    private CharacterMaster LoadMaster(string charaID)
    {
        return MasterLoader.LoadCharaMaster(charaID);
    }

    private void SetSprite(Sprite sprite)
    {
        Assert.IsNotNull(_renderer);
        Assert.IsNotNull(sprite);
        if (_renderer == null) return;

        _renderer.sprite = sprite;
    }
}
