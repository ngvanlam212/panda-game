using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{

    public void nextLevel(){
        Application.LoadLevel("Level1");
    }

    public void rank()
    {
        Application.LoadLevel("LeaderBoard");
    }

    public void quit()
    {
        Application.Quit();
    }
}
