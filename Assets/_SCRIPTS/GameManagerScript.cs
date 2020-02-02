using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    public float remainingTime;
    public float maxTime;

    private float curCheckTimer = 1.0f;
    [SerializeField]
    private GameObject lostScene;

    [SerializeField]
    private Sprite[] remainingTimeSprites;
    [SerializeField]
    private Image Timer;

    private int timerIndex;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = maxTime;
        timerIndex = (int)((remainingTime / maxTime) * remainingTimeSprites.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timerIndex = remainingTimeSprites.Length - (int)((remainingTime / maxTime) * remainingTimeSprites.Length);
      //  Debug.Log(remainingTimeSprites.Length - (int)((remainingTime / maxTime) * remainingTimeSprites.Length));
        Timer.sprite = remainingTimeSprites[timerIndex % (remainingTimeSprites.Length)];
        remainingTime -= Time.deltaTime;
        curCheckTimer -= Time.deltaTime;
        if (remainingTime < 0)
        {
            if (!checkLevel())
            {
                Timer.gameObject.SetActive(false);
                lostScene.SetActive(true);
            }

        }
        if(curCheckTimer < 0)
        {
            if (checkLevel())
            {
                Debug.Log("you win");
               Application.LoadLevel(Application.loadedLevel + 1);
            }
            curCheckTimer = 1;
        }
    }


    private bool checkLevel()
    {
        GameObject[] curNonRepaired = GameObject.FindGameObjectsWithTag("brokenPiece");
        if (curNonRepaired.Length == 0)
            return true;
        else
            return false;
    }
}
