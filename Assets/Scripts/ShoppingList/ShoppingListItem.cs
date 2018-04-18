using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItem : MonoBehaviour {

    public Image porductImage;
    public Text productNameText;

    public Button removeButton;

    private Product product;

    void Start () {
        
        removeButton.onClick.AddListener(HandleClick);
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