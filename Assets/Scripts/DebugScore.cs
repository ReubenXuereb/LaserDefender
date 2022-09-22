using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScore : MonoBehaviour
{
    // Start is called before the first frame update
   public void ResetInt(string s)
   {
       PlayerPrefs.SetInt(s, 0);
   }
}
