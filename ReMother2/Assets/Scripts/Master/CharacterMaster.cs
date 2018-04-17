using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterMaster : ScriptableObject
{
    public string charaName;
    public string talkMessage;

    public Sprite charaSprite;

    public int hp;
    public int power;

    public static readonly string MasterPathHeader = "Masters";
}
