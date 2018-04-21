using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProductInformationDisplay : MonoBehaviour {

    public GameObject ProductInfoPanel;

    public Text productNameText;
    public Text productInfoText;
    public Text productPriceText;
    public Image productImage;
    public Text productDescriptionText;

    public Button closeButton;
    public Button addButton;

    public Product product; //TODO: Change to private

    void Start () {
        closeButton.onClick.AddListener(ClosePanel);
        addButton.onClick.AddListener(AddProductToShoppinglist);
        RefreshDisplay();
	}

    private void AddProductToShoppinglist() {
        Data.AddProduct(product);
        GameObject.Find("ShoppinglistContent").GetComponent<ShoppingList>().RefreshDisplay();
    }

    public void Setup(Product product) {
        this.product = product;
        RefreshDisplay();
    }

    private void ClosePanel() {
        ProductInfoPanel.SetActive(false);
    }

    private void RefreshDisplay() {
        productNameText.text = product.productName;
        productInfoText.text = product.productInfo;
        productPriceText.text = product.productPrice;
        productImage.sprite = product.productImage;
        productDescriptionText.text = product.productDescription;
    }
}
