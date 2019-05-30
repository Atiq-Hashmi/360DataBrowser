using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CamControl : MonoBehaviour
{
    [SerializeField] Transform player;
   
    void Start()
    {
       
    }


   //to avoid the movement of cam only
 
    void Update()
    {
        Vector3 currentPos = transform.position;
        
        
        currentPos.x = player.transform.position.x;
        currentPos.z = player.transform.position.z;

        transform.position = currentPos;


    }
  
    }

