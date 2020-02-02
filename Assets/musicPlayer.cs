using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        
        if(Timer == 0)
        {
            randomizeMusic();
        }
    }
    [SerializeField]
    private AudioClip[] musics;
    private int curSelected;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            randomizeMusic();
        }
        if (Input.GetKeyDown("p"))
        {
            randomizeMusic();
        }
    }

    private void randomizeMusic()
    {
        int selectedMusic = Random.Range(0, musics.Length);
        while(curSelected == selectedMusic)
            selectedMusic = Random.Range(0, musics.Length);
        curSelected = selectedMusic;
        GetComponent<AudioSource>().clip = musics[selectedMusic];
        Timer = GetComponent<AudioSource>().clip.length;
        GetComponent<AudioSource>().Play();
    }
}
