using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighlightButton : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
  
    public void showcolor()
    {
        gameObject.GetComponent<Image>().color = Color.yellow;
    }
    public void hidecolor()
    {
        gameObject.GetComponent<Image>().color = Color.white;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
