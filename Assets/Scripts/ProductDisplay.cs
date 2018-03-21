using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour {

    public ProductModel product;

    public Text productName;
    public Image productImage;
    public Text productPrice;
    public Text productInfo;

    void Start() {
        productName.text = product.productName;
        productImage.sprite = product.productImage;
        productPrice.text = product.productPrice;
        productInfo.text = product.productInfo;
    }
}
