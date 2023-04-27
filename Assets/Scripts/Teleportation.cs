using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Teleportation : MonoBehaviour
{
	private bool PointerOn;
   
	//private Button button;
    OpenTeleportMenu opm;

    private Transform reticle;
	public GameObject teleportLocation;
   
    public GameObject shoppingCart;
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
    	//button=GetComponent<Button>();
    
        reticle=GameObject.Find("Character").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if(PointerOn && Input.GetButtonDown("js7"))
        {
            TeleportCharacter();
        }
      
    }
    public void OnPointerEnter()
    {
       
        PointerOn=true;
        gameObject.GetComponent<Image>().color=Color.yellow;

    }
    public void OnPointerExit()
    {
        gameObject.GetComponent<Image>().color = Color.white;
        Debug.Log("Calling");
        PointerOn=false;
       
    }
    public void TeleportCharacter()
    {
       

        
    	reticle.transform.position = teleportLocation.transform.position;
        reticle.transform.rotation = Quaternion.LookRotation(teleportLocation.transform.position - reticle.transform.position);
        GameObject.Find("TeleportMenu2").SetActive(false);
        GameObject.Find("door").transform.Find("TeleportMenu1").gameObject.SetActive(true);
       
        gameObject.GetComponent<Image>().color = Color.white;
      
        PointerOn = false;





    }
    
}
