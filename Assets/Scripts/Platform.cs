using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static event System.Action Broken;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Egg")
        {
            print("BrokenEgg"); 
            if (Broken != null)
                Broken();
            Destroy(other.gameObject);
        }
           
    }
}
