using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RotateCartWithCam : MonoBehaviour
{
    GameObject cart;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("js11"))
        {
            cart = GameObject.Find("shoppingcart");
            if (cart.transform.IsChildOf(GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform))
            {
                Vector3 forward = transform.forward;



                cart.transform.position = transform.position + transform.forward * 5f;
                cart.transform.position = new Vector3(cart.transform.position.x - 1.5f, (float)0.75, cart.transform.position.z + 1.25f);

                cart.transform.rotation = Quaternion.LookRotation(transform.forward);
                cart.transform.rotation *= Quaternion.Euler(-90f, 180f, 0f);
                cart.transform.rotation = Quaternion.Euler(-90f, cart.transform.rotation.eulerAngles.y, cart.transform.rotation.eulerAngles.z);
            }
           
        }

    }
}