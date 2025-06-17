using System;

#region BASE_DATA
public abstract class BaseData
{
    public string StringKey;
    public int    IntKey;
}
#endregion



#region ITEM_DATA
[Serializable]
public class ItemData : BaseData
{
    public enum ItemType
    {
        ShortRange,
        LongRange
    }

    public string   ItemNameKR;
    public string   ItemNameEN;
    public ItemType Type;
    public int      AtkPower;
}
#endregion

#region MONSTER_DATA
[Serializable]
public class MonsterData : BaseData
{
    public string MonsterNameKR;
    public string MonsterNameEN;
    public int    HP;
    public int    AtkPower;
}
#endregion

#region SKILL_DATA
[Serializable]
public class SkillData : BaseData
{
    public enum SkillType
    {
        NonTarget,
        Target
    }

    public string    SkillNameKR;
    public string    SkillNameEN;
    public SkillType Type;
    public float     Range;
    public int       AtkPower;
}
#endregion