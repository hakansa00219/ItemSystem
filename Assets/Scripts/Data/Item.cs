using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public string name;
    public string type;
    public Info info;
    public Damage damage;
    //public int level;
    //public Stats stats;
    public string description;
    //public Texture2D texture;

    public Item WithDamage(Damage damage)
    {
        this.damage = damage;
        return this;
    }
    public Item With<T>(T info) where T : Info
    {
        this.info = info;
        return this;
    }

}
public class Main
{
    public Main()
    {
        Item woodAxe = new Item().With(new Damage(IElement.Elements.Fire));
    }
}

public class Info
{
   


}
public class Level : Info{ }
//public class Stats : Info{ }
public class Texture : Info{ }
public class Damage : Info, IDamage
{
    public Damage(IElement.Elements element)
    {
        this.element = element;
    }

    public IElement.Elements element { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}

public class ValuePair
{
    public int minValue;
    public int maxValue;
}




public interface IDamage : IElement
{
   
}
public interface IElement
{
    public Elements element { get; set; }

    public enum Elements
    {
        Ice,Fire
    };
}

