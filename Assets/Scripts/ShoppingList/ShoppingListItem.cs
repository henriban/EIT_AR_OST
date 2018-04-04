using System;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItem : MonoBehaviour {

    public ProductModel product;

    public Image porductImage;
    public Text productNameText;

    public Button removeButton;

    void Start () {

        porductImage.sprite = product.productImage;
        productNameText.text = product.productName;

        removeButton.onClick.AddListener(HandleClick);
	}

    private void HandleClick() {
        Debug.Log("Remove ");
    }
}
