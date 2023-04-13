using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnscript : MonoBehaviour
{
    
    public GameObject objectPrefab;
    
    private BoxCollider basketCollider;
 
    // Start is called before the first frame update
    void Start()
    {
        basketCollider = transform.parent.GetComponent<BoxCollider>();
        int c = 1;
      
       if(name.Equals("Eggs"))
        {
            
            for (int i = 1; i < 5; i++)
            {
                
                    GameObject obj = Instantiate(objectPrefab);

               
                    obj.transform.localPosition = objectPrefab.transform.parent.GetChild(i-1).transform.position+ new Vector3(0, 0, objectPrefab.transform.localScale.z + 2.5f);
                
                   
                    obj.transform.SetParent(objectPrefab.transform.parent);
                    obj.transform.localScale = objectPrefab.transform.localScale;
                    obj.name = objectPrefab.name + (c++);
                

            }
        }
        //else if (name.Equals("Pringles") || name.Equals("ChipsY"))
        //{
        //    for (int i = 1; i < 8; i++)
        //    {

        //        GameObject obj = Instantiate(objectPrefab);
                
               
        //        obj.transform.position = new Vector3(objectPrefab.transform.parent.GetChild(i - 1).transform.position.x, objectPrefab.transform.parent.GetChild(i - 1).transform.position.y, objectPrefab.transform.parent.GetChild(i - 1).transform.position.z + 2f);


        //        obj.transform.SetParent(objectPrefab.transform.parent);
        //        obj.transform.localScale = objectPrefab.transform.localScale;
        //        obj.transform.localRotation = objectPrefab.transform.localRotation;
        //        obj.name = objectPrefab.name + (c++);
                

        //    }
        //}
        else if (name.Equals("Milks"))
        {
            //float zPosObj = objectPrefab.transform.localPosition.z;
            //float cubePos = transform.parent.transform.Find("Cube").transform.localPosition.z;

            
           
                for (int i = 1; i < 8; i++)
                {
                    GameObject obj = Instantiate(objectPrefab);


                    obj.transform.position = new Vector3(objectPrefab.transform.parent.GetChild(i - 1).transform.position.x, objectPrefab.transform.parent.GetChild(i - 1).transform.position.y, objectPrefab.transform.parent.GetChild(i - 1).transform.position.z + 1.75f);


                    obj.transform.SetParent(objectPrefab.transform.parent);
                    obj.transform.localScale = objectPrefab.transform.localScale;
                    obj.transform.localRotation = objectPrefab.transform.localRotation;
                    obj.name = objectPrefab.name + (c++);
                }
            
            
                
          

        }
       

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
