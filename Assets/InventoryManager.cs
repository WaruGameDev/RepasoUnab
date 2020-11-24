using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[System.Serializable]
public class Item
{
    public string nameItem;
    public Sprite icon;
    public int stock;
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager sInventoryManager;
    public List<Item> items;
    public List<ItemVisual> itemVisuals;
    public GameObject itemVisualBase;
    public GameObject panel;
    private bool findItem;

    private void Awake()
    {
        sInventoryManager = this;
    }
    public void AddItem(Item itemToAdd)
    {
        if (items.Count > 0)
        {
            foreach (Item item in items)
            {
                if (item.nameItem == itemToAdd.nameItem)
                {
                    item.stock += itemToAdd.stock;
                    findItem = true;
                }
                
            }
            if(findItem == true)
            {
                foreach (ItemVisual itemVisual in itemVisuals)
                {
                    if (itemVisual.itemName == itemToAdd.nameItem)
                    {
                        itemVisual.stockNumber += itemToAdd.stock;
                        itemVisual.stockVisual.text = itemVisual.stockNumber.ToString();

                    }
                }
            }
            else
            {
                items.Add(itemToAdd);
                GameObject itemVisual = Instantiate(itemVisualBase, panel.transform);
                itemVisual.GetComponent<ItemVisual>().stockVisual.text = itemToAdd.stock.ToString();
                itemVisual.GetComponent<ItemVisual>().stockNumber = itemToAdd.stock;
                itemVisual.GetComponent<ItemVisual>().iconVisual.sprite = itemToAdd.icon;
                itemVisual.GetComponent<ItemVisual>().itemName = itemToAdd.nameItem;
                itemVisuals.Add(itemVisual.GetComponent<ItemVisual>());
            }
            
        }
        else
        {
            items.Add(itemToAdd);
            GameObject itemVisual = Instantiate(itemVisualBase, panel.transform);
            itemVisual.GetComponent<ItemVisual>().stockVisual.text = itemToAdd.stock.ToString();
            itemVisual.GetComponent<ItemVisual>().stockNumber = itemToAdd.stock;
            itemVisual.GetComponent<ItemVisual>().iconVisual.sprite = itemToAdd.icon;
            itemVisual.GetComponent<ItemVisual>().itemName = itemToAdd.nameItem;
            itemVisuals.Add(itemVisual.GetComponent<ItemVisual>());

        }
    }
    public void RemoveItem(Item itemToRemove, int count)
    {
        if (items.Count > 0)
        {
            foreach (Item item in items)
            {
                if (item.nameItem == itemToRemove.nameItem)
                {
                    item.stock -= count;
                }
            }
        }
    }
    public void UpdateInventoryVisual()
    {
        
    }
}
