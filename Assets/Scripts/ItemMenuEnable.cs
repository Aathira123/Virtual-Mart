using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemMenuEnable : MonoBehaviour
{
    public GameObject itemmenu;
    GameObject cam;
    
    GameObject highlightedobj;
    int flag;
    Dictionary<string, (float price, DateTime? expiryDate)> dict;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Character").transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").gameObject;
        flag = -1;
        
       
    }
    // Update is called once per frame
    void Update()
    {
        
      
        if (gameObject.GetComponent<Outline>().enabled && Input.GetButtonDown("js2"))
            {
            

            itemmenu.SetActive(true);

                itemmenu.transform.SetParent(gameObject.transform);
                highlightedobj = itemmenu.transform.parent.gameObject;

            itemmenu.transform.position = (highlightedobj.transform.position + cam.transform.position) / 2f;
                itemmenu.transform.rotation = Quaternion.LookRotation(highlightedobj.transform.position - cam.transform.position);
            }

            if (itemmenu != null)
            {
                if (itemmenu.transform.GetChild(0).GetComponent<Image>().color == Color.yellow)
                {
                    flag = 0;
                }
                if (itemmenu.transform.GetChild(1).GetComponent<Image>().color == Color.yellow)
                {
                    flag = 1;
                }
            if (itemmenu.transform.GetChild(2).GetComponent<Image>().color == Color.yellow)
            {
                flag = 2;
            }


        }
      
       
          if(flag==0)
            {
            if (dict == null)
            {
                dict = DisplayItemDetails.Getdict();
            }
            if (dict != null)
            {
                if (Input.GetButton("js7"))
                {
                    itemmenu.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                    GameObject.Find("EmptyObj").transform.Find("PriceDisplay").gameObject.SetActive(true);
                    highlightedobj = itemmenu.transform.parent.gameObject;
                    if (highlightedobj != null)
                    {

                        if (dict.ContainsKey(highlightedobj.transform.parent.name.ToLower()))
                        {
                           
                            string key = highlightedobj.transform.parent.name.ToLower();
                           
                            Transform originalButtonTransform = itemmenu.transform.Find("Price");
                            Button originalButton = originalButtonTransform.GetComponent<Button>();
                            GameObject pricedisplaybutton = GameObject.Find("PriceDisplay").transform.Find("pricedisplay").gameObject;
                            pricedisplaybutton.GetComponentInChildren<TextMeshProUGUI>().text = dict[key].price.ToString() + "$";


                            itemmenu.transform.GetChild(0).GetComponent<Image>().color = Color.white;

                            itemmenu.SetActive(false);
                        } 

                    }
                }
                else if (Input.GetButtonUp("js7"))
                {
                    flag = -1;
                    
                    GameObject.Find("EmptyObj").transform.Find("PriceDisplay").gameObject.SetActive(false);
                    
               

                }
            }
          

        }

        if (flag == 1)
        {
            if (dict == null)
            {
                dict = DisplayItemDetails.Getdict();
            }
            if (dict != null)
            {
                if (Input.GetButton("js7"))
                {
                    itemmenu.transform.GetChild(0).GetComponent<Image>().color = Color.white;
                    GameObject.Find("EmptyObj").transform.Find("PriceDisplay").gameObject.SetActive(true);
                    highlightedobj = itemmenu.transform.parent.gameObject;
                    if (highlightedobj != null)
                    {

                        if (dict.ContainsKey(highlightedobj.transform.parent.name.ToLower()))
                        {

                            string key = highlightedobj.transform.parent.name.ToLower();

                            Transform originalButtonTransform = itemmenu.transform.Find("Price");
                            Button originalButton = originalButtonTransform.GetComponent<Button>();
                            GameObject pricedisplaybutton = GameObject.Find("PriceDisplay").transform.Find("pricedisplay").gameObject;
                            if (dict[key].expiryDate!=null)
                            {
                                pricedisplaybutton.GetComponentInChildren<TextMeshProUGUI>().text = dict[key].expiryDate?.ToString("MM/dd/yyyy");
                            }
                           
                              else
                            {
                                pricedisplaybutton.GetComponentInChildren<TextMeshProUGUI>().text = "2 Weeks";
                                }

                            pricedisplaybutton.GetComponentInChildren<TextMeshProUGUI>().fontSize = 24;
                            itemmenu.transform.GetChild(1).GetComponent<Image>().color = Color.white;
                            itemmenu.SetActive(false);
                        }

                    }
                }
                else if (Input.GetButtonUp("js7"))
                {
                    flag = -1;

                   
                    GameObject.Find("EmptyObj").transform.Find("PriceDisplay").gameObject.SetActive(false);
                  

                }
            }

            
        }
        if (flag == 2)
        {
            if (Input.GetButton("js7"))
            {
                itemmenu.transform.GetChild(2).GetComponent<Image>().color = Color.white;
                itemmenu.SetActive(false);
               
                flag = -1;
            }
           
        }
    
      




    }

    public void setItemMenu(GameObject newmenu)
    {
        itemmenu = newmenu;
    }
   
}

