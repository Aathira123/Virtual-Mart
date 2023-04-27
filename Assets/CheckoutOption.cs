using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutOption : MonoBehaviour
{
    Button[] buttons;
    bool allGreen;
    // Start is called before the first frame update
    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        allGreen = false;
    }

    // Update is called once per frame
    void Update()
    {

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
            Debug.Log("All buttons are green");
        }
    }
}
