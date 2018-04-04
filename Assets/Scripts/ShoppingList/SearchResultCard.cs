using UnityEngine;
using UnityEngine.UI;

public class SearchResultCard : MonoBehaviour {

    public ProductModel product;

    public Image productImage;
    public Text productNameText;

    //public Button addButton;

    void Start() {

        productImage.sprite = product.productImage;
        productNameText.text = product.productName;

    }
}