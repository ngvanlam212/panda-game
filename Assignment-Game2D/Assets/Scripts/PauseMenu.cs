using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour{

    private bool pause = false;
    public GameObject pauseUI;

	public TextMeshProUGUI speed;
	public TextMeshProUGUI jump;
    public TextMeshProUGUI damage;

    public Player player;
    public AttackTrigger attackTrigger;

    void Start(){
        pauseUI.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<AttackTrigger>();
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;

        }

        speed.text = ("Speed: " + player.speed);
        jump.text = ("Jump: " + player.jumpPow);
        damage.text = ("Damage: " + attackTrigger.damage);

    }

    public void resume(){
        pause = false;
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit(){
        Application.Quit();
    }

}
