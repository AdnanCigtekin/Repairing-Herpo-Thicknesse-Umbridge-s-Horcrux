using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startPlayingSeq(0);
    }
    [SerializeField]
    private ImageSequencer[] sequencers;
    [SerializeField]
    private GameObject[] scenes;

    private int currentScene;

    public bool isPlaying = true;

    private int currentSequence;

    // Update is called once per frame
    void Update()
    {
        //if (isPlaying)
        //{
            if (!sequencers[currentSequence].hasPlayed)
            {
                isPlaying = false;
            }
        //}
    }

    public void changeScene(int nextScene)
    {
        resetAllAnims();
        scenes[currentScene].SetActive(false);
        scenes[nextScene].SetActive(true);
        currentScene = nextScene;

    }

    public void startPlayingSeq(int newSeq)
    {
        sequencers[newSeq].PlayNow();
        currentSequence = newSeq;
    }

    private void resetAllAnims()
    {
        for (int i = 0; i < sequencers.Length; i++)
        {
            sequencers[i].hasPlayed = false;
        }
    }

    public void startPlayingSeq(string newSeq)
    {
        
        for (int i = 0; i < sequencers.Length; i++)
        {
            if(sequencers[i].name == newSeq)
            {
                currentSequence = i;
            }
        }
        sequencers[currentSequence].PlayNow();
    }

    public void startPlayingSeq(string newSeq,bool reverse)
    {
        
        for (int i = 0; i < sequencers.Length; i++)
        {
            if (sequencers[i].name == newSeq)
            {
                currentSequence = i;
            }
        }
        sequencers[currentSequence].PlayNow(reverse);
    }

    public void startPlayingSeq(string newSeq, Sprite[] sprites)
    {

        for (int i = 0; i < sequencers.Length; i++)
        {
            if (sequencers[i].name == newSeq)
            {
                currentSequence = i;
            }
        }
        sequencers[currentSequence].PlayNow(sprites);
    }

    public bool getSequenceSituation()
    {
        Debug.Log("Sequence situation : " + sequencers[currentSequence].name);
        if (sequencers[currentSequence].isPlaying)
            return true;
        else
            return false;
    }
    public bool getReverseSituation()
    {
        Debug.Log("Sequence situation : " + sequencers[currentSequence].name);
        return sequencers[currentSequence].isReverse;

    }

    public bool areSequenceEqual(Sprite[] tmpSeq)
    {
        Debug.Log("Equal? :" + tmpSeq.Equals(sequencers[currentSequence]));



        return tmpSeq.Equals(sequencers[currentSequence].sequence);
    }
}
