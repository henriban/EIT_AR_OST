using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class ShoppingList : MonoBehaviour
{
    private List<Product> itemList;

    public Transform contentPanel;
    public SimpleObjectPool productCardObjectPool;

    private bool colorListGray = true;

    void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        itemList = Data.ShoppingList;
        RemoveButtons();
        AddShoppingListItems();
    }

    private void RemoveButtons()
    {
        colorListGray = true;
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            productCardObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddShoppingListItems()
    {
        foreach (var item in itemList)
        {
            GameObject newProductCard = productCardObjectPool.GetObject();
            newProductCard.transform.SetParent(contentPanel, false);

            if (colorListGray)
            {
                newProductCard.GetComponent<Image>().color = new Color(0.97f, 0.97f, 0.97f);
                colorListGray = false;
            }
            else
            {
                newProductCard.GetComponent<Image>().color = new Color(0.99f, 0.99f, 0.99f);
                colorListGray = true;
            }


            ShoppingListItem listItem = newProductCard.GetComponent<ShoppingListItem>();
            listItem.Setup(item);
        }
    }

    public void RemoveShoppinglistItem(Product itemToRemove)
    {
        Data.RemoveProduct(itemToRemove);
        RefreshDisplay();
    }
}
