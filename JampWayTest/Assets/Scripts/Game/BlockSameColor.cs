using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSameColor : MonoBehaviour {

    //private bool firstOne = false;
    //public Color[] colors;

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "block")//firstOne &&
        {
            other.gameObject.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
            //other.gameObject.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
        }
        //if (!firstOne) firstOne = true;
    }
}
