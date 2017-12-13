using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public static event System.Action Catched;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Egg")
        {
            if (Catched != null)
                Catched();
            Destroy(other.gameObject);
        }
    }
}
