using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Intractable {

    public Item item;
    public override void Intearct()
    {
        base.Intearct();
      
        pickUP();
        
        
    }
    void pickUP() 
    {
        bool wasPickUp = Inventory.instance.Add(item);
        if (wasPickUp)
        {
            Destroy(gameObject);
            Debug.Log("Item Pickup" + " " + item.name);    
        }
    }
}
