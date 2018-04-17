using UnityEngine;

public class MasterLoader
{
    public static CharacterMaster LoadCharaMaster(string charaID)
    {
        string masterPath = (CharacterMaster.MasterPathHeader + "/" + charaID);
        var master = Resources.Load(masterPath) as CharacterMaster;

        return master;
    }
}
