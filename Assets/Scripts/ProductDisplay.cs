using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour {

    public ProductModel product;

    public Text productName;
    public Text productInfo;
    public Image productImage;
    public Text productPrice;
    public Text productInStore;
    public Text productDescription;

    void Start() {
        productName.text = product.productName;
        productInfo.text = product.productInfo;
        productImage.sprite = product.productImage;
        productPrice.text = product.productPrice + ",- / stk";
        productInStore.text = product.inStore ? "På lager" : "Ikke på lager";
        productDescription.text = product.productDescription;
        
    }
}
