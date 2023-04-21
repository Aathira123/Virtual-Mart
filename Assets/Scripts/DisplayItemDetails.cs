using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayItemDetails : MonoBehaviour
{
    public static  Dictionary<string, (float price, DateTime? expiryDate)> itemData;
    string item1,item2,item3,item4,item5;
    // Start is called before the first frame update
    void Start()
    {
        
       

        itemData = new Dictionary<string, (float price, DateTime? expiryDate)>();

        // Add item data to the dictionary
        itemData["bananas"] = (1.56f, null);
        itemData["onion"] = (3.75f, null);
        itemData["potatoes"] = (2.75f, null);
        itemData["mango"] = (1.25f, null);
        itemData["bacons"] = (5.5f, null);
        itemData["chicken"] = (9.75f, null);
        itemData["milks"] = (4.65f, new DateTime(2023, 04, 28));
        itemData["breads"] = (3.99f, new DateTime(2023, 04, 17));
        itemData["cookies"] = (4.95f, new DateTime(2023, 05, 04));
        itemData["pancakes"] = (3.58f, new DateTime(2023, 07, 02));
        itemData["oats"] = (2.25f, new DateTime(2023, 09, 12));
        itemData["cereals"] = (3.45f, new DateTime(2023, 09, 12));
        itemData["chips"] = (3.39f, new DateTime(2023, 08, 15));
        itemData["pringles"] = (3.39f, new DateTime(2023, 08, 15));
        itemData["fridgemilk"] = (6.5f, new DateTime(2023, 05, 01));
        itemData["juices"] = (5.45f, new DateTime(2023, 05, 06));
        itemData["eggs"] = (8.65f, new DateTime(2023, 06, 01));
    }
    public static Dictionary<string, (float price, DateTime? expiryDate)> Getdict()
    {

        return itemData;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("selected shopping list: "+selectlist);

    }
}

