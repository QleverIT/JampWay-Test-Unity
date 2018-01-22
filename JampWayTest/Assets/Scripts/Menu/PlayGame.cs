using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayGame : MonoBehaviour {

    public static bool starGame;//*
    private bool check;
    public Text GameName, TapToPlay, lesson, record;
    public GameObject Buttons, m_cube, platform_1, spawn_block, deletBlocks, diamondCount, music;

    private void OnMouseDown()
    {        
        if (check == false)
        {
            check = true;

            if (music.activeSelf)
            {
                for (int i = 0; i < music.transform.parent.transform.childCount; i++)
                {
                    music.transform.parent.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            GameName.text = "0";
            TapToPlay.gameObject.SetActive (false);
            Buttons.GetComponent<ScrollObjects>().speed = -10f;
            Buttons.GetComponent<ScrollObjects>().checkPos = -130;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            platform_1.GetComponent<Animation>().Play("PlanformPlay");
            StartCoroutine(SpawnBlockBlock());
            record.gameObject.SetActive(true);
            Invoke("LessonON", 2f);
            diamondCount.SetActive(true);
            starGame = true;
        }
       else if(check && lesson.gameObject.activeSelf)//&& cubeJamp.countBlock>0
            lesson.gameObject.SetActive(false);
    }

    IEnumerator SpawnBlockBlock()
    {
        yield return new WaitForSeconds(1f);
        spawn_block.GetComponent<SpawnBlock>().enabled = true;

        m_cube.AddComponent<Rigidbody>();
        m_cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        deletBlocks.SetActive(true);
    }
    
    void LessonON()
    {
        lesson.gameObject.SetActive(true);
    }
}
