using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CokeMachineSpawn : MonoBehaviour
{
    public GameObject cokeCanPrefab;
    int flag = 0;
    public AudioClip buttonSound;
    private AudioSource audioSource;

    public void onPushEnter()
    {
        flag = 1;
        
    }

    public void onPushExit()
    {
        flag = 0;
   
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 1 && Input.GetButtonDown("js7"))
        {
            StartCoroutine(SpawnCokeCanAfterSound());
            
        }
    }

    IEnumerator SpawnCokeCanAfterSound()
    {
        // Play audio cue
        audioSource.Play();

        // Wait for audio clip to finish playing
        yield return new WaitForSeconds(buttonSound.length);

        // Spawn coke can
        GameObject cokeCan = Instantiate(cokeCanPrefab, transform.position, Quaternion.identity);
        cokeCan.transform.position = new Vector3(79.73f, 4f, -82.99f); // move the can forward from the spawn point
        cokeCan.AddComponent<Outline>();
        cokeCan.GetComponent<Outline>().enabled = false;
        cokeCan.AddComponent<OutlineBehaviour>();
        
    }
}
