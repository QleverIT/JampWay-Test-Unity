using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countBlock : MonoBehaviour {

    private Text counterBlock;

    private void Start()
    {
        counterBlock = GetComponent<Text>();
    }

    void Update () {
        if(cubeJamp.nextBlock)
            counterBlock.text = cubeJamp.countBlock+"";
	}
}
