using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HamfriesDisable : MonoBehaviour
{
    public GameObject[] hamburger;
    public GameObject[] fries;
    public AudioClip soundClip;
    public Button[] menuButtons;

    private int currentIndexh = 0;
    private int currentIndexf = 0;
    private int flag = 0;

    void Update()
    {
        if (flag == 1 && Input.GetButtonDown("js7"))
        {
            if (currentIndexh < hamburger.Length)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
                //AudioSource audioSource = hamburger[currentIndexh].GetComponent<AudioSource>();
                audioSource.clip = soundClip;
                audioSource.Play();
                hamburger[currentIndexh].SetActive(false);
                currentIndexh++;
            }
        }
        if (flag == 2 && Input.GetButtonDown("js7"))
        {
            if (currentIndexf < fries.Length)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
                //AudioSource audioSource = fries[currentIndexf].GetComponent<AudioSource>();
                audioSource.clip = soundClip;
                audioSource.Play();
                fries[currentIndexf].SetActive(false);
                currentIndexf++;
            }
        }

        if(currentIndexh==hamburger.Length){
            menuButtons[0].gameObject.SetActive(false);
             
        }
        if(currentIndexf==fries.Length){
              
                menuButtons[1].gameObject.SetActive(false); 
        }
    }

    public void onburgerenter()
    {
        flag = 1;
    }

    public void onfriesenter()
    {
        flag = 2;
    }

    public void onexit()
    {
        flag = 0;
    }
}
