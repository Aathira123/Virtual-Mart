using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AddRigidBody : MonoBehaviour
{
    GameObject[] taggedObjects;
    int c ;
    // Start is called before the first frame update
    void Start()
    {
        
        c = 0;
        GameObject.Find("PriceDisplay").SetActive(false);
        GameObject.Find("InstCanvas").SetActive(false);
        GameObject.Find("pleasepickcart").SetActive(false);
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
        if (Input.GetButtonDown("js5") && c==0)
        {
            transform.Find("InstCanvas").gameObject.SetActive(true);
            c++;
        }
        else if(Input.GetButtonDown("js5") && c== 1)
        {
            transform.Find("InstCanvas").gameObject.SetActive(false);
            c--;
        }
        
    }
}
