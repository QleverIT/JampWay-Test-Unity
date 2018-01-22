using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubs : MonoBehaviour {

    private bool moved = true;
    private Vector3 target;

    private void Start()
    {
        target = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (cubeJamp.nextBlock)
        {
            if (target != transform.position)
                transform.position = Vector3.MoveTowards(transform.position, target, 5f * Time.deltaTime);
            else if (target == transform.position && !moved)
            {
                target = new Vector3(transform.position.x - 2.75f, transform.position.y + 2.29f, transform.position.z);
                cubeJamp.jamp = false;
                moved = true;
            }
            if (cubeJamp.jamp)
                moved = false;
        }
    }
}
