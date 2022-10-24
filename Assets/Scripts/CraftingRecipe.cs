using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ItemAmount{
    public Item Item;
    [Range(1, 999)]
    public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(IItemContainer itemContainer){
        foreach (ItemAmount itemAmount in Materials){
            if(itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.Amount){
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer){
        if(CanCraft(itemContainer)){
            foreach (ItemAmount itemAmount in Materials){
                for(int i = 0; i < itemAmount.Amount; i++){
                    itemContainer.RemoveItem(itemAmount.Item.ID);
                }
            }
            foreach (ItemAmount itemAmount in Results){
                for(int i = 0; i < itemAmount.Amount; i++){
                    itemContainer.AddItem(Instantiate(itemAmount.Item));
                }
            }
        }
    }
}
