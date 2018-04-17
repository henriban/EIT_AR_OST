using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItem : MonoBehaviour {

    public Image porductImage;
    public Text productNameText;

    public Button removeButton;

    private Product product;
    private ShoppingList scrollList;

    void Start () {
        
        removeButton.onClick.AddListener(HandleClick);
	}

    public void Setup(Product currentProduct, ShoppingList currentScrollList) {

        product = currentProduct;
        scrollList = currentScrollList;

        porductImage.sprite = product.productImage;
        productNameText.text = product.productName;
    }

    private void HandleClick() {
        //scrollList.TransferItemToOtherShop(product);
        GameObject.Find("ShoppinglistContent").GetComponent<ShoppingList>().RemoveShoppinglistItem(product);
    }
}