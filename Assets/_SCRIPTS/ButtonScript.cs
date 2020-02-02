using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private bool gotClicked = false;
    private bool waitingforanim = true;


  
    private ImageSequencer mySeq;
    private string myAction;

    [SerializeField]
    private MenuManager menuManager;

    [SerializeField]
    private Sprite[] howGoBackSequence;
    [SerializeField]
    private Sprite[] howGoForwardSequence;
    private void Start()
    {
        mySeq = GetComponent<ImageSequencer>();
    }

    private void Update()
    {

        if (myAction == "menucredits")
        {
            if (!menuManager.getSequenceSituation() && menuManager.getReverseSituation())
            {
                //menuManager.startPlayingSeq("menu");
                Debug.Log("came back to menu");
                menuManager.changeScene(0);
            }else
            {
                Debug.Log("coming to menu");
            }
        }else if(myAction == "menuhow")
        {
            if (!menuManager.getSequenceSituation() && menuManager.areSequenceEqual(howGoBackSequence))
            {
                //menuManager.startPlayingSeq("menu");
                Debug.Log("came back to menu");
                menuManager.changeScene(0);
            }
            else
            {
                Debug.Log("coming to menu");
            }
        }

        if (gotClicked)
        {
            if (waitingforanim)
            {
                if (mySeq.hasPlayed)
                {
                    switch (myAction)
                    {
                        case "play":
                            SceneManager.LoadScene(1);
                            //Application.LoadLevel(1);
                            break;
                        case "how":
                            //Add how to play here
                            menuManager.changeScene(2);
                            menuManager.startPlayingSeq("how", howGoForwardSequence);
                            mySeq.hasPlayed = false;
                            Debug.Log("how");
                            break;
                        case "credits":
                            menuManager.changeScene(1);
                            menuManager.startPlayingSeq("credits",false);
                            mySeq.hasPlayed = false;
                            Debug.Log("credits");
                            //Add credits here
                            break;
                        case "exit":
                            Application.Quit();
                            Debug.Log("exited");
                            mySeq.hasPlayed = false;
                            break;
                        case "menucredits":
                            Debug.Log("going to menu");
                            menuManager.startPlayingSeq("credits", true);
                            mySeq.hasPlayed = false;
                            break;
                        case "menuhow":
                            Debug.Log("going to menu");
                            menuManager.startPlayingSeq("how", howGoBackSequence);
                            mySeq.hasPlayed = false;
                            break;
                        default:
                            break;
                    }
                    gotClicked = false;
                }
            }
        }

    }

    public void doAction(string action)
    {
        gotClicked = true;
        myAction = action;
        mySeq.PlayNow();

                
    }
}
