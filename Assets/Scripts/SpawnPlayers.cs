using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX, minZ, maxX, maxZ;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randompos = new Vector3(Random.Range(minX, maxX), -51f, Random.Range(minZ, maxZ));
        GameObject instobj =PhotonNetwork.Instantiate(playerPrefab.name, randompos, Quaternion.identity);
        instobj.transform.SetParent(GameObject.Find("Character").transform.Find("XRCardboardRig").transform.Find("HeightOffset").transform.Find("Main Camera").transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
