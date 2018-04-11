using System.Collections.Generic;

public static class Data {
    private static List<Product> shoppingList;
    private static List<Product> allProducts;

    public static List<Product> ShoppingList {
        get {
            return shoppingList;
        }

        //set {
        //    shoppingList = value;
        //}
    }

    public static List<Product> AllProducts {
        get {
            return allProducts;
        }

        set {
            allProducts = value;
        }
    }

    public static void AddProduct(Product product) {
        shoppingList.Add(product);
    }

    public static void RemoveProduct(Product product) {
        shoppingList.Remove(product);
    }
}