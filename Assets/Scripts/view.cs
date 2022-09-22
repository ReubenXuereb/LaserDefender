using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view : MonoBehaviour
{
    // Start is called before the first frame update
    
    
         private void Awake()
     {
         //Set screen size for Standalone
 #if UNITY_STANDALONE
         Screen.SetResolution(564, 960, false);
         Screen.fullScreen = false;
 #endif
     }
        
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}

