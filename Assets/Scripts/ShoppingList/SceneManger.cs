using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour {

    public List<Product> itemList;

    void Start () {
        // Adds all product to the "DB"
        Data.AllProducts = itemList;
        Data.ShoppingList = new List<Product>();
	}	
}
