using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
  
    public static Inventory instance;
    public int space = 20;
    #region Singeton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Lebih dari 1 instance ditemukan");
            return;
        }
        instance = this;
    }
    #endregion
    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Kapasitas Penuh");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null) 
            {
                onItemChangedCallback.Invoke();    
            }
        }
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
