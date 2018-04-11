using UnityEngine;
using UnityEngine.UI;

public class SearchResultCard : MonoBehaviour {

    private Product product;


    public Image productImage;
    public Text productNameText;

    //public Button addButton;

    void Start() {


    }

    public void Setup(Product currentProduct) {

        product = currentProduct;        

        productImage.sprite = product.productImage;
        productNameText.text = product.productName;
    }
}