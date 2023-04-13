using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectCart : MonoBehaviour
{

    GameObject cam;
    private bool isPointerOver = false;
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
            cart.transform.position=cam.transform.position + cam.transform.forward * 4f;
            cart.transform.position = new Vector3(cart.transform.position.x+1.5f, (float)0.75, cart.transform.position.z+1.25f);
            cart.transform.rotation= Quaternion.Euler(-90, 0, -45);
           
        }
    }
}
