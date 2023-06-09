using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ShopCartButtonScript  : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cart;
    GameObject cam;
    AudioSource audioSource; // Declare an AudioSource variable
    public AudioClip attachSoundClip; // Add a public AudioClip variable for the attach sound effect
    int flag = -1;
    void Start()
    {
        cam = GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").gameObject;
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component to the same GameObject as this script
    }

    public void onPointerAttEnter()
    {
        flag = 1;
  
    }
    public void onPointerDetEnter()
    {
        flag = 2;
   
    }
    public void onPointerExit()
    {
        flag = 0;
    
    }
    // Update is called once per frame
    void Update()
    {

        if (flag == 1 && Input.GetButtonDown("js7"))
        {
            
            cart.transform.SetParent(GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).transform);

            //cart.transform.position = cam.transform.position + cam.transform.forward * 4f;
            //cart.transform.position = new Vector3(cart.transform.position.x + 1.5f, (float)0.75, cart.transform.position.z + 1.25f);
            //cart.transform.rotation = Quaternion.Euler(-90, 0, -75);

            cart.transform.position = cam.transform.position + cam.transform.forward * 5.75f;
            cart.transform.position = new Vector3(cart.transform.position.x - 1.5f, (float)0.75, cart.transform.position.z + 1.25f);
            
            audioSource.clip = attachSoundClip; // Set the clip to the attach sound effect
            audioSource.Play(); // Play the clip
        }

        if (flag == 2 && Input.GetButtonDown("js7"))
        {
            cart.transform.parent = null;
            audioSource.clip = attachSoundClip; // Set the clip to the detach sound effect
            audioSource.Play(); // Play the clip
        }

    }
}
