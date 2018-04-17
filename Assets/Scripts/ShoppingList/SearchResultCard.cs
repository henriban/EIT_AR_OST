using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SearchResultCard : MonoBehaviour {

    private Product product;

    public Image productImage;
    public Text productNameText;

    public Button addButton;

    void Start() {

        addButton.onClick.AddListener(HandleClick);
    }


    public void Setup(Product currentProduct) {

        product = currentProduct;        

        productImage.sprite = product.productImage;
        productNameText.text = product.productName;
    }

    private void HandleClick() {
        Data.AddProduct(product);
        GameObject.Find("ShoppinglistContent").GetComponent<ShoppingList>().RefreshDisplay();
        
    }
}
