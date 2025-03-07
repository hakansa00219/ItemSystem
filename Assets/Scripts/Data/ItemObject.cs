using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemObject : ScriptableObject
{
    private const float LabelWidth = 150;

    [HorizontalGroup("Data", 300)]
    [PreviewField(300)]
    [HideLabel]
    [VerticalGroup("Data/Left")]
    public Texture2D texture;
    [VerticalGroup("Data/Left")]
    [Button("SpawnUI",ButtonSizes.Medium)]
    public void SpawnUI()
    {
        ItemUICreator.Get().CreateUIPanel(this);
    }
    [VerticalGroup("Data/Left")]
    [PreviewField(300)]
    [HideLabel]
    public GameObject model;


    #region STATS
    [VerticalGroup("Data/Attributes")]
    [BoxGroup("Data/Attributes/Stats")]
    [LabelWidth(LabelWidth)]
    public string itemName;
    [BoxGroup("Data/Attributes/Stats")]
    [LabelWidth(LabelWidth)]
    public Type type;
    [BoxGroup("Data/Attributes/Stats")]
    [LabelWidth(LabelWidth)]
    [GUIColor("GetRarityColor")]
    public Rarity rarity;
    [BoxGroup("Data/Attributes/Stats")]
    [LabelWidth(LabelWidth)]
    public List<Stats> stats = new List<Stats>();
    #endregion

    #region DEPENDENCIES
    [BoxGroup("Data/Attributes/Dependencies")]
    [LabelWidth(LabelWidth)]
    public List<Dependencies> dependencies = new List<Dependencies>();

    #endregion

    #region UPGRADES
    [BoxGroup("Data/Attributes/Upgrades")]
    [LabelWidth(LabelWidth)]
    public List<Upgradables> upgrades = new List<Upgradables>();

    #endregion

    #region DESCRIPTION
    [BoxGroup("Data/Attributes/Description")]
    [TextArea]
    public string description;
    #endregion


    public Color GetRarityColor()
    {
        switch(rarity)
        {
            case Rarity.Normal : return Color.white;
            case Rarity.Magic : return Color.cyan;
            case Rarity.Rare: return Color.yellow;
            case Rarity.Unique: return Color.magenta;
            case Rarity.Legendary: return new Color(1, 0.5f, 0);
            case Rarity.Mythic: return Color.red;
            case Rarity.Set: return Color.green;
            default: return Color.white;
        }
    }
    

}
[Serializable]
public class Stats
{
    [HideLabel]
    public Type type;

    [ShowIf("type",Type.Damage)]

    public int damage;
    [ShowIf("type",Type.TickRate)]

    public float rate;

    public enum Type
    {
        Damage,
        TickRate,
    }
}

[Serializable]
public class Dependencies
{
    [HideLabel]
    public Type type;

    [Range(1, 99)]
    public int level;

    public enum Type
    {
        Woodcutting,
        Mining,
        Attack,
        Magic,
        Crafting,
    }
}

[Serializable]
public class Upgradables 
{
    [HideLabel]
    public Type type;


    [ShowIf("@type == Type.IncreasePercentTickRate || " +
            "type == Type.DecreasePercentTickRate")]
    public int tickRate;

    [ShowIf("@type == Type.IncreaseDamage || type == Type.DecreaseDamage")]
    public int damage;

    public enum Type
    {
        IncreasePercentTickRate,
        DecreasePercentTickRate,
        IncreaseDamage,
        DecreaseDamage,
    }
}

public enum Type
{
    Axe,Pickaxe,Sword
}

public enum Rarity
{
    Normal,Magic,Rare,Unique,Legendary,Mythic,Set
}