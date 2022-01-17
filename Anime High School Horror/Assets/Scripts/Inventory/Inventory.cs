using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items;
    public static Inventory instance;
    GameObject temp;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        items = new List<GameObject>();
    }

    public bool SearchinInventory(string name)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == name)
            {
                temp = items[i];
                Debug.Log("Found " + temp.name);
                break;
            }
        }
        if (temp != null)
            return true;
        else
            return false;
    }
}
