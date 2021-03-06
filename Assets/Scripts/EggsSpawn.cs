using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsSpawn : MonoBehaviour
{
    public GameObject eggPref;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FallingDown());
    }

    IEnumerator FallingDown()
    {
        while (true)
        {
            var poin = new Vector2(Random.Range(-PlayerController.halfWidthScreen + 1, PlayerController.halfWidthScreen - 1), PlayerController.hightScreen);
            var newEgg = (GameObject)Instantiate(eggPref, poin, Quaternion.identity);
            newEgg.transform.parent = transform;
            yield return new WaitForSeconds(2f);
        }
    }

}
