using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class ShoppingList : MonoBehaviour {

    private List<Product> itemList;

    public Transform contentPanel;
    public SimpleObjectPool productCardObjectPool;
  
    void Start() {

        RefreshDisplay();
    }

   public void RefreshDisplay() {
        Debug.Log("Refresh");
        itemList = Data.ShoppingList;
        RemoveButtons();
        AddShoppingListItems();        
    }

    private void RemoveButtons() {
        while (contentPanel.childCount > 0) {
            GameObject toRemove = transform.GetChild(0).gameObject;
            productCardObjectPool.ReturnObject(toRemove);
        }
    }

    private void AddShoppingListItems() {
        for (int i = 0; i < itemList.Count; i++) {
            Product item = itemList[i];
            GameObject newProductCard = productCardObjectPool.GetObject();
            newProductCard.transform.SetParent(contentPanel);

            ShoppingListItem listItem = newProductCard.GetComponent<ShoppingListItem>();
            listItem.Setup(item, this);
        }
    }

    public void TransferItemToOtherShop(Product item) {

        AddItem(item);
        RemoveItem(item, this);

        RefreshDisplay();
    }

    void AddItem(Product itemToAdd) {
        itemList.Add(itemToAdd);
    }

    private void RemoveItem(Product itemToRemove, ShoppingList shopList) {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--) {
            if (shopList.itemList[i] == itemToRemove) {
                shopList.itemList.RemoveAt(i);
            }
        }
    }

    public void RemoveShoppinglistItem(Product itemToRemove) {
        Data.RemoveProduct(itemToRemove);
        RefreshDisplay();
    }
}