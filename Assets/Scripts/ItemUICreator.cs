using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUICreator : MonoBehaviour
{
    //Static tek bir obje �eklinde kullan�l�yor �imdi
    //�lerde her kullan�ld��� zaman yeni bir obje olu�turup kullan�lmas� daha iyi olabilir
    private GameObject canvas;
    public static ItemUICreator Get() 
    {
        GameObject canvas = GameObject.Find("Canvas");
        
        if(canvas == null) return null;

        if(canvas.TryGetComponent(out ItemUICreator creator))
        {
            return creator;
        }
        else
        {
            return canvas.AddComponent<ItemUICreator>();
        }
    }


    public void CreateUIPanel(ItemObject item)
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject itemPrefab = Instantiate(Resources.Load<GameObject>("ItemInstance"), canvas.transform);

        itemPrefab.name = item.name;

    }

}
