using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField joinInput;
    public TMP_InputField createInput;
    public Button[] lobbyButtons;
    private int selectedButtonIndex = 0;
    private bool joystickMoved = false;
    Color myColor;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SuperMarket");
    }

    public override void OnCreatedRoom()
    {
       



    }
    // Start is called before the first frame update
    void Start()
    {
        myColor = new Color(0x11 / 255f, 0xCF / 255f, 0x65 / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (lobbyButtons[0].gameObject.activeInHierarchy)
        {
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
            selectedButtonIndex = Mathf.Clamp(selectedButtonIndex, 0, lobbyButtons.Length - 1);

            // Update the colors of the buttons
            for (int i = 0; i < lobbyButtons.Length; i++)
            {
                if (i == selectedButtonIndex)
                {
                    // This button is selected, so color it using the selected color
                    lobbyButtons[i].GetComponent<Image>().color = myColor;

                 
                }
                else
                {
                    // This button is not selected, so use the default color
                    lobbyButtons[i].GetComponent<Image>().color = Color.white;
                   
                }
            }
            //Debug.Log("selected button: " + selectedButtonIndex);

            // Reset the joystickMoved flag when the joystick returns to its resting position
            if (verticalInput > -0.1f && verticalInput < 0.1f)
            {
                joystickMoved = false;
            }
        }
        if(selectedButtonIndex==0 && Input.GetButtonDown("js7"))
        {
           
            CreateRoom();
        }
        else if (selectedButtonIndex == 1 && Input.GetButtonDown("js7"))
        {
            JoinRoom();
        }
    }
}
