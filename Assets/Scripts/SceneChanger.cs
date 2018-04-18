using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadARMap()
    {
        SceneManager.LoadScene("ARmap");
    }

    public void LoadAisleView()
    {
        SceneManager.LoadScene("aisleview");
    }

    public void LoadShoppingList()
    {
        SceneManager.LoadScene("ShoppingListScene");
    }
}