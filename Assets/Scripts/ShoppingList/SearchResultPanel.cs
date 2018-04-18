using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SearchResultPanel : MonoBehaviour
{
    private List<Product> itemList;
    private List<Product> searchList = new List<Product>();

    public Transform searchResultPanel;
    public SimpleObjectPool searchResultObjectPool;

    public InputField searchField;

    void Start()
    {
        itemList = Data.AllProducts;
        InitList();

        searchField.onValueChanged.AddListener(delegate { HandleSearchFieldChange(); });
        var grid = searchResultPanel.gameObject.GetComponent<GridLayoutGroup>();
        var rect = searchResultPanel.gameObject.GetComponent<RectTransform>();
        const int colCount = 2;
        var cellWidth = rect.rect.width / colCount - grid.padding.horizontal - grid.spacing.x * (colCount-1)*2;
                         
        grid.cellSize = new Vector2(
            cellWidth,
            cellWidth/1.618033989f
        );
    }

    private void InitList()
    {
        foreach (var item in itemList)
        {
            var searchResultCard = searchResultObjectPool.GetObject();
            searchResultCard.transform.SetParent(searchResultPanel, false);

            var listItem = searchResultCard.GetComponent<SearchResultCard>();
            listItem.Setup(item);
        }
    }

    private void HandleSearchFieldChange()
    {
        if (searchField.text.Length > 0)
        {
            Search(searchField.text);
        }
        else
        {
            RemoveOldList();
            InitList();
        }
    }

    private void Search(string str)
    {
        foreach (Product product in itemList)
        {
            if (!product.productName.ToLower().Contains(str.ToLower())) continue;
            if (!searchList.Contains(product))
            {
                searchList.Add(product);
            }
        }

        RemoveOldList();
        UpdateList();
        searchList = new List<Product>();
    }

    private void RemoveOldList()
    {
        while (searchResultPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            searchResultObjectPool.ReturnObject(toRemove);
        }
    }

    private void UpdateList()
    {
        foreach (Product product in searchList)
        {
            GameObject searchResultCard = searchResultObjectPool.GetObject();
            searchResultCard.transform.SetParent(searchResultPanel);

            SearchResultCard listItem = searchResultCard.GetComponent<SearchResultCard>();
            listItem.Setup(product);
        }
    }
}