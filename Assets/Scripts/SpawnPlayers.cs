using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);  Vector3 randompos = new Vector3(0, 0, 0);
        GameObject instobj = PhotonNetwork.Instantiate(playerPrefab.name, randompos, Quaternion.identity);
        instobj.name = "Character"+ PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
