using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidBody : MonoBehaviour
{
    GameObject[] taggedObjects;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("PriceDisplay").SetActive(false);
        GameObject itemmenu = GameObject.Find("ItemMenu");
        
        taggedObjects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject obj in taggedObjects)
        {
            // Check if the object already has the component
            if (obj.GetComponent<Rigidbody>() == null)
            {
                // Add the component to the object
                obj.AddComponent<Rigidbody>();
                obj.GetComponent<Rigidbody>().isKinematic = true;
            }
       
           
            ItemMenuEnable x=obj.AddComponent<ItemMenuEnable>();
            x.setItemMenu(itemmenu);
           


        }
        itemmenu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
