using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SearchResultCard : MonoBehaviour {

    public GameObject productInformationPanel;
    private GameObject canvas;

    private Product product;

    public Image productImage;
    public Text productNameText;

    public Button addButton;

    void Start() {

        canvas = GameObject.Find("Canvas");

        addButton.onClick.AddListener(HandleClick);
        gameObject.transform.GetComponent<Button>().onClick.AddListener(HandleProductInformationClick);
    }

    public void Setup(Product currentProduct) {

        product = currentProduct;

        productImage.sprite = product.productImage;
        productNameText.text = product.productName;
    }

    private void HandleProductInformationClick() {
        
        productInformationPanel = Instantiate(productInformationPanel);
        productInformationPanel.transform.SetParent(canvas.transform, false);
        productInformationPanel.GetComponent<ProductInformationDisplay>().Setup(product);
    }

    private void HandleClick() {
        Data.AddProduct(product);
        GameObject.Find("ShoppinglistContent").GetComponent<ShoppingList>().RefreshDisplay();
        
    }
}
