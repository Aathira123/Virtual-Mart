using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using Photon.Pun;

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
      
        cam = GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").gameObject;

    


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
            if (gameObject.GetComponent<Outline>().enabled && Input.GetButtonDown("js10"))
            {

                if (GameObject.Find("shoppingcart").transform.IsChildOf(GameObject.Find("Character").transform))
                {
                    
                    cart = GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform.Find("shoppingcart").gameObject;
                    cam.transform.position = cart.transform.position - cart.transform.forward * -12f;
                    string s = cart.transform.Find("BillCanvas/BillButton").GetComponentInChildren<TextMeshProUGUI>().text;
                    s = s.Substring(0, s.Length - 1);
                    double p = (double)dict[interactableObject.transform.parent.name.ToLower()].price;

                    double currentbill = double.Parse(s);
                    cart.transform.Find("BillCanvas/BillButton").GetComponentInChildren<TextMeshProUGUI>().text =
             ((currentbill + p).ToString("0.00")) + "$";
                    
                    transform.SetParent(cam.transform);
                    
                    cart.transform.SetParent(null);



                }
                else
                {
                    GameObject.Find("EmptyObj").transform.Find("pleasepickcart").gameObject.SetActive(true);
                    StartCoroutine(DeactivateAfterDelay());
                }
               



            }
            if (transform.IsChildOf(cam.transform) && Input.GetButtonDown("js11"))
            {
                
                transform.SetParent(GameObject.Find("shoppingcart").gameObject.transform);
                GameObject.Find("shoppingcart").transform.SetParent(GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform);
                transform.GetComponent<Rigidbody>().useGravity = true;
                transform.GetComponent<Rigidbody>().isKinematic = false;
                cart.transform.position = cam.transform.position + cam.transform.forward * 5.75f;
                
                cart.transform.position = new Vector3(cart.transform.position.x, (float)0.75, cart.transform.position.z);



            }
        }
        
    }
    IEnumerator DeactivateAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        GameObject.Find("EmptyObj").transform.Find("pleasepickcart").gameObject.SetActive(false);
    }
    public GameObject GetInteractableObject()
    {
        return interactableObject; // make the interactable object accessible to other scripts
    }
}
