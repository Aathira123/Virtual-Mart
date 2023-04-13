using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playSelect : MonoBehaviour
{
    
        public Button[] menuButtons;
         private int selectedButtonIndex = 0;
         private int selectedButtonIndex2 = 1; // Index of the currently selected button
    private bool joystickMoved = false;
    
   // public AudioClip highlightSoundClip;
    private bool soundPlayed;
// Start is called before the first frame update
    void Start()
    {
        menuButtons[2].gameObject.SetActive(false); // Hide the first two buttons
        menuButtons[3].gameObject.SetActive(false);
        menuButtons[4].gameObject.SetActive(false);
        menuButtons[5].gameObject.SetActive(false);
         menuButtons[7].gameObject.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
      if(menuButtons[0].gameObject.activeInHierarchy){
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
        selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, menuButtons.Length - 1);

        // Update the colors of the buttons
        for (int i = 0; i < menuButtons.Length; i++)
        {
            if (i == selectedButtonIndex)
            {
                // This button is selected, so color it using the selected color
                menuButtons[i].GetComponent<Image>().color = Color.yellow;
                
                if (!soundPlayed)
            {
              
                soundPlayed = true;
            }
            }
            else
            {
                // This button is not selected, so use the default color
                menuButtons[i].GetComponent<Image>().color = Color.white;
                soundPlayed = false;
            }
        }
        //Debug.Log("selected button: " + selectedButtonIndex);

        // Reset the joystickMoved flag when the joystick returns to its resting position
        if (verticalInput > -0.1f && verticalInput < 0.1f)
        {
            joystickMoved = false;
        }
      }
      else
      {
        float verticalInput1 = Input.GetAxis("Vertical");
        if (verticalInput1 > 0.5f && !joystickMoved)
        {
            // Move selection up
            selectedButtonIndex2--;
            joystickMoved = true;
        }
        else if (verticalInput1 < -0.5f && !joystickMoved)
        {
            // Move selection downx
            selectedButtonIndex2++;
            joystickMoved = true;
        }

        // Clamp the selected button index to the range [0, buttons.Length - 1]
        selectedButtonIndex2 = Mathf.Clamp(selectedButtonIndex2, 0, menuButtons.Length - 1);

        // Update the colors of the buttons
        for (int i = 2; i < 4; i++)
        {
            if (i == selectedButtonIndex2)
            {
                // This button is selected, so color it using the selected color
                menuButtons[i].GetComponent<Image>().color = Color.yellow;
                // if (!audioSource.isPlaying)
                // {
                //     audioSource.PlayOneShot(highlightSoundClip);
                // }
            }
            else
            {
                // This button is not selected, so use the default color
                menuButtons[i].GetComponent<Image>().color = Color.white;
            }
        }
                
        if (verticalInput1 > -0.1f && verticalInput1 < 0.1f)
        {
            joystickMoved = false;
        }
      }
       
        switch (selectedButtonIndex)
        {
            //////////////////////////////////////////////////////////////////////////////////
            case 0:
                if (Input.GetButton("js7"))
              {
                // if (!audioSource.isPlaying)
                // {
                //     audioSource.PlayOneShot(highlightSoundClip);
                // }
                menuButtons[0].gameObject.SetActive(false);
                menuButtons[1].gameObject.SetActive(false);
                menuButtons[2].gameObject.SetActive(true);
                menuButtons[3].gameObject.SetActive(true);
                menuButtons[7].gameObject.SetActive(true);
              }
             break;
             case 1:
                if (Input.GetButton("js7"))
              {
                //code for multiplayer
              }
             break;

        }

        if (selectedButtonIndex2==2)
        {
            // if (!audioSource.isPlaying)
            //     {
            //         audioSource.PlayOneShot(highlightSoundClip);
            //     }
            menuButtons[5].gameObject.SetActive(false);
             menuButtons[4].gameObject.SetActive(true);
                if (Input.GetButtonDown("js7"))
              {
                Debug.Log("insode case 2 ");
                SceneManager.LoadScene("SuperMarket");

              }
            
        }else if(selectedButtonIndex2==3){
            // if (!audioSource.isPlaying)
            //     {
            //        e audioSource.PlayOneShot(highlightSoundClip);
            //     }ew
            
            menuButtons[4].gameObject.SetActive(false);
            menuButtons[5].gameObject.SetActive(true);
            if (Input.GetButtonDown("js7"))
              {
                Debug.Log("insode case 3 ");
                SceneManager.LoadScene("SuperMarket");

              }
        }

    }
}
