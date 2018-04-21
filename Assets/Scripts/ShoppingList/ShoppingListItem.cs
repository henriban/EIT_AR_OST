using System;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItem : MonoBehaviour {

    public Image porductImage;
    public Text productNameText;

    public GameObject productInformationPanel;
    private GameObject canvas;

    public Button removeButton;

    private Product product;

    void Start () {

        canvas = GameObject.Find("Canvas");

        removeButton.onClick.AddListener(HandleClick);
        gameObject.transform.GetComponent<Button>().onClick.AddListener(HandleProductInformationClick);

	}

    private void HandleProductInformationClick() {
        
        productInformationPanel = Instantiate(productInformationPanel);
        productInformationPanel.transform.SetParent(canvas.transform, false);
        productInformationPanel.GetComponent<ProductInformationDisplay>().Setup(product);
    }

    public void Setup(Product currentProduct) {

        product = currentProduct;

        porductImage.sprite = product.productImage;
        productNameText.text = product.productName;
    }

    private void HandleClick() {
        GameObject.Find("ShoppinglistContent").GetComponent<ShoppingList>().RemoveShoppinglistItem(product);
    }
}