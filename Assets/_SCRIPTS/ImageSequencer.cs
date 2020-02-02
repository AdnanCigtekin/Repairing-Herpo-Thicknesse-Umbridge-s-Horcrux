using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSequencer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        myImg = GetComponent<Image>();
    }
    [SerializeField]
    public Sprite[] sequence;

    [SerializeField]
    private float speed;
    private float curTimer = 1.0f;
    private Image myImg;

    private int curSprite;

    public bool isPlaying = false;
    public bool hasPlayed = false;
    public string name;
    public bool isReverse;
    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            curTimer -= speed * Time.deltaTime;
            if (curTimer < 0)
            {
                myImg.sprite = sequence[curSprite];
                if (!isReverse)
                {
                    curSprite++;
                    curTimer = 1.0f;
                    if (curSprite == sequence.Length)
                    {
                        hasPlayed = true;
                        isPlaying = false;
                        curSprite = 0;
                    }
                }
                else
                {
                    //Debug.Log("Playing : " + sequence[curSprite].name);
                    curSprite--;
                    curTimer = 1.0f;
                    if (curSprite == 0)
                    {
                        hasPlayed = true;
                        isPlaying = false;
                        curSprite = sequence.Length-1;
                    }
                }
        }
        }

    }

    public void PlayNow()
    {
        isPlaying = true;
    }

    public void PlayNow(Sprite[] sprites)
    {
        isPlaying = true;
        sequence = sprites;
    }

    public void PlayNow(bool newReverse)
    {
        isPlaying = true;
        isReverse = newReverse;
        if (isReverse)
            curSprite = sequence.Length - 1;
        else
            curSprite = 0;
    }
}
