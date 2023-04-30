using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class ColorSelectedItem : MonoBehaviour
{
    bool pointeron;
    Button[] buttons;
    bool allGreen;
    private int selectedButtonIndex = 0;
    private bool joystickMoved = false;
    void Start()
    {
        GameObject.Find("EmptyObj").transform.Find("Checkout").gameObject.SetActive(false);
        pointeron = false;
        buttons = gameObject.transform.parent.GetComponentsInChildren<Button>();
        allGreen = true;
    }

    public void OnPointerEnter()
    {
        pointeron = true;
    }

    public void onPointerExit()
    {
        pointeron = false;
    }

    void Update()
    {
        if (pointeron && Input.GetButtonDown("js7"))
        {
            // Check if the current color is green
            if (gameObject.GetComponent<Image>().color == Color.green)
            {
                // If the color is green, change it back to white
                gameObject.GetComponent<Image>().color = Color.white;
            }
            else
            {
                // If the color is not green, change it to green
                gameObject.GetComponent<Image>().color = Color.green;
            }
            foreach (Button button in buttons)
            {
                Image image = button.GetComponent<Image>();
                if (image.color != Color.green)
                {
                    allGreen = false;
                    break;
                }
            }
            if (allGreen)
            {
                GameObject.Find("EmptyObj").transform.Find("Checkout").gameObject.SetActive(true);
                GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).GetComponent<CharacterMovement>().enabled = false;
            }
        }
        if (allGreen)
        {
            GameObject checkout = GameObject.Find("EmptyObj").transform.Find("Checkout").gameObject;
            float verticalInput = Input.GetAxis("Vertical");
           
                if (verticalInput > 0.5f && !joystickMoved)
                {
                    // Move selection up
                    selectedButtonIndex--;
                    joystickMoved = true;
                }
                else if (verticalInput < -0.5f && !joystickMoved)
                {
                    // Move selection downx
                    selectedButtonIndex++;
                    joystickMoved = true;
                }

                // Clamp the selected button index to the range [0, buttons.Length - 1]
                selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, 1);

                // Update the colors of the buttons
                for (int i = 0; i <=1; i++)
                {
                    if (i == selectedButtonIndex)
                    {
                        // This button is selected, so color it using the selected color
                        checkout.transform.GetChild(i).GetComponent<Image>().color = Color.green;

                     
                    }
                    else
                    {
                    // This button is not selected, so use the default color
                    checkout.transform.GetChild(i).GetComponent<Image>().color = Color.white;
                       
                    }
                }
             
                if (verticalInput > -0.1f && verticalInput < 0.1f)
                {
                    joystickMoved = false;
                }
            if (selectedButtonIndex == 0 && Input.GetButtonDown("js7"))
            {
                Application.Quit();
            }
            else if(selectedButtonIndex == 1 && Input.GetButtonDown("js7"))
            {
                GameObject.Find("EmptyObj").transform.Find("Checkout").gameObject.SetActive(false);
                GameObject.Find("Character" + PhotonNetwork.LocalPlayer.ActorNumber.ToString()).GetComponent<CharacterMovement>().enabled = true;
            }

            
        }
    }
}
