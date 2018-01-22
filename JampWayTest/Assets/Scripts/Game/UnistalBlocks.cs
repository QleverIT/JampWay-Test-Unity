using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnistalBlocks : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "block")
            Destroy(other.gameObject, 1f);
    }
}
