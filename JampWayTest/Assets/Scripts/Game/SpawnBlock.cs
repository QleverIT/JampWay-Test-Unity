using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour {
    public GameObject block, allCubs, diamond;
    private GameObject blockInst, diamondInst;
    private Vector3 blockPoz;
    private bool onPlace;
    private float speed = 5f;
    public GameObject[] cubShop;
    private Material blockMaterialNow;
	
	void Start () {
        for(int i = 0; i < cubShop.Length; i++)
        {
            if(cubShop[i].name == PlayerPrefs.GetString("nowCube"))
            {
                blockMaterialNow = cubShop[i].GetComponent<MeshRenderer>().material;
                break;
            }
        }
        spawn();
    }
    private void Update()
    {
        if (blockInst.transform.position != blockPoz && !onPlace)
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPoz, Time.deltaTime * speed);
        else if (blockInst.transform.position == blockPoz)
            onPlace = true;

        if(cubeJamp.jamp && cubeJamp.nextBlock)
        {
            spawn();
            onPlace = false;
        }
        if (diamondInst != null)
            diamondInst.transform.eulerAngles = Camera.main.transform.eulerAngles;
    }

    float RandScale()
    {
        float rend;
        if (Random.Range(0, 100) > 80)
            rend = Random.Range(1.2f, 2.2f);
        else rend = Random.Range(1.2f, 1.5f);

        return rend;
    }

    void spawn()
    {
        blockInst = Instantiate(block, new Vector3(4, -5, 0), Quaternion.identity) as GameObject;
        blockPoz = new Vector3(Random.Range(1f, 1.9f), Random.Range(-0.5f, -2f), 0);
        blockInst.transform.localScale = new Vector3(RandScale(), 0.5f, 2f);
        blockInst.transform.parent = allCubs.transform;

        
        blockInst.GetComponent<MeshRenderer>().material = blockMaterialNow;

        if (cubeJamp.countBlock % 1 == 0 && cubeJamp.countBlock!=0) //%7
        {
            diamondInst = Instantiate(diamond, new Vector3(blockInst.transform.position.x, blockInst.transform.position.y + 0.6f, blockInst.transform.position.z), Quaternion.Euler(Camera.main.transform.eulerAngles));
            diamondInst.transform.parent = blockInst.transform;
        }
    }



}
