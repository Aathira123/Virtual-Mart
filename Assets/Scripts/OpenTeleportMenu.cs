using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTeleportMenu : MonoBehaviour
{
    public GameObject teleportmenu;
    public GameObject categorymenu;
    // Start is called before the first frame update
    void Start()
    {
        categorymenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (teleportmenu.transform.Find("teleport").GetComponent<Image>().color == Color.yellow && Input.GetButtonDown("js7"))
        {
            teleportmenu.transform.Find("teleport").GetComponent<Image>().color = Color.white;
            teleportmenu.SetActive(false);
            categorymenu.SetActive(true);
        }

    }
}
