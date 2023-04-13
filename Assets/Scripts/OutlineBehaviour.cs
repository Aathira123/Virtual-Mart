using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class OutlineBehaviour : MonoBehaviour
{
    Outline outline;
    //ReadJsonFile rjs;
    DisplayItemDetails di;
    private GameObject cam;
    private GameObject interactableObject;
    GameObject cart;
    Dictionary<string, (float price, DateTime? expiryDate)> dict;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
  
        outline.enabled=false;

        cam = GameObject.Find("Character").transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").gameObject;

    


    }
    public void OnPointerEnter()
    {
        
       
        
            outline.enabled=true;


        interactableObject = gameObject;
        
        
           
        
    }
    public void OnPointerExit()
    {
        
        if(outline!=null)
        {
          
            outline.enabled=false;
            interactableObject = null;
            
        }
    }
    public void Update()
    {
        if(dict == null)
        {
            dict = DisplayItemDetails.Getdict();
        }
        if (dict != null)
        {
            if (gameObject.GetComponent<Outline>().enabled && Input.GetButtonDown("js5"))
            {

                if (GameObject.Find("shoppingcart").transform.IsChildOf(GameObject.Find("Character").transform))
                {
                    
                    cart = GameObject.Find("Character").transform.Find("shoppingcart").gameObject;
                    string s = cart.transform.Find("BillCanvas/BillButton").GetComponentInChildren<TextMeshProUGUI>().text;
                    s = s.Substring(0, s.Length - 1);
                    double p = (double)dict[interactableObject.transform.parent.name.ToLower()].price;

                    double currentbill = double.Parse(s);
                    cart.transform.Find("BillCanvas/BillButton").GetComponentInChildren<TextMeshProUGUI>().text =
             ((currentbill + p).ToString("0.00")) + "$";

                    transform.SetParent(cart.transform.Find("emptyposition").transform);
                    transform.localPosition = Vector3.zero;
                   
                }
                else
                {
                    GameObject.Find("shoppingcart").transform.SetParent(GameObject.Find("Character").transform);
                   
                    cart = GameObject.Find("Character").transform.Find("shoppingcart").gameObject;
                    cart.transform.position = cam.transform.position + cam.transform.forward * 4f;
                    cart.transform.position = new Vector3(cart.transform.position.x + 1.5f, (float)0.75, cart.transform.position.z + 1.25f);
                    cart.transform.rotation = Quaternion.Euler(-90, 0, -45);
                    transform.SetParent(cart.transform);
                    transform.localPosition = new Vector3(-0.25f, 0.5f, 0.32f);
                   
                }



            }
        }
        
    }
    public GameObject GetInteractableObject()
    {
        return interactableObject; // make the interactable object accessible to other scripts
    }
}
