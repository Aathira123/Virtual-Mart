using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCart : MonoBehaviour
{

    GameObject cam;
    private bool isPointerOver = false;
    string item1,item2,item3,item4,item5;
    public void OnPointerEnter()
    {
        isPointerOver = true;
}

    public void OnPointerExit()
    {
        isPointerOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {
         item1 = PlayerPrefs.GetString("item1");
        item2 = PlayerPrefs.GetString("item2");
        item3 = PlayerPrefs.GetString("item3");
        item4 = PlayerPrefs.GetString("item4");
        item5 = PlayerPrefs.GetString("item5");
        cam = GameObject.Find("Character").transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPointerOver && Input.GetButtonDown("js7") )
        {
           
            
            GameObject cart = GameObject.Find("shoppingcarts").transform.GetChild(0).gameObject;
            cart.name= "shoppingcart";
           cart.transform.SetParent(GameObject.Find("Character").transform);
           cart.transform.Find("ShoppingList").transform.Find("Button").GetComponentInChildren<TextMeshProUGUI>().text=item1;
            cart.transform.Find("ShoppingList").transform.Find("Button1").GetComponentInChildren<TextMeshProUGUI>().text=item2;
             cart.transform.Find("ShoppingList").transform.Find("Button2").GetComponentInChildren<TextMeshProUGUI>().text=item3;
              cart.transform.Find("ShoppingList").transform.Find("Button3").GetComponentInChildren<TextMeshProUGUI>().text=item4;
               cart.transform.Find("ShoppingList").transform.Find("Button4").GetComponentInChildren<TextMeshProUGUI>().text=item5;
            cart.transform.position=cam.transform.position + cam.transform.forward * 4f;
            cart.transform.position = new Vector3(cart.transform.position.x+1.5f, (float)0.75, cart.transform.position.z+1.25f);
            cart.transform.rotation= Quaternion.Euler(-90, 0, -45);
           
        }
    }
}
