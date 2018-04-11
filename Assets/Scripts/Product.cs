using UnityEngine;

[CreateAssetMenu(fileName = "New Product", menuName = "Product")]
public class Product : ScriptableObject {

    public string productName;
    public string productInfo;
    public string productPrice;
    public Sprite productImage;
    public string productDescription;
    public bool inStore;

}
