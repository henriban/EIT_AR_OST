using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchResultPanel : MonoBehaviour {

    private List<Product> itemList;

    public Transform searchResultPanel;
    public SimpleObjectPool searchResultObjectPool;

	void Start () {
        itemList = Data.AllProducts;
        InitList();
    }

    private void InitList() {
        for (int i = 0; i < itemList.Count; i++) {
            Product item = itemList[i];
            GameObject searchResultCard = searchResultObjectPool.GetObject();
            searchResultCard.transform.SetParent(searchResultPanel);

            SearchResultCard listItem = searchResultCard.GetComponent<SearchResultCard>();
            listItem.Setup(item);
        }
    }


}
