﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManger : MonoBehaviour {

    public List<Product> itemList;

    void Start () {
        // Adds all product to the "DB"
        Data.AllProducts = itemList;
        if(Data.ShoppingList == null)
        {
            Data.ShoppingList = new List<Product>();
        }
        
	}	
}
