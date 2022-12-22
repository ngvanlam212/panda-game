using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Door : MonoBehaviour {
 
    public int Levelload = 1;
    public Score s;
 
    // Use this for initialization
    void Start () {
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            saveScore();
            s.Inputtext.text = ("Press E to enter");
        }
    }
 
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                saveScore();
                SceneManager.LoadScene(Levelload);
            }
        }
    }
 
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            s.Inputtext.text = ("");
        }
    }
 
    void saveScore()
    {
        PlayerPrefs.SetInt("score", s.score);
    }
}