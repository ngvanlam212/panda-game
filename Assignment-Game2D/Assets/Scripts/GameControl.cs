using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl: MonoBehaviour {

    public TextMeshProUGUI moneyText;
	public static int moneyAmount;
	int isHatSold = 0;

    public Animator anim;
    public GameObject hat;
	public Button hatButton;
    public Button shoeButton;
	public Button swordButton;
	public Button heartButton;
    public TextMeshProUGUI toastText;

    private bool on = false;
    public GameObject shopItem;

    public Player player;
    public AttackTrigger attackTrigger;

    public Score s;

    void Start () {
        shopItem.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<AttackTrigger>();
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        anim = GameObject.Find("ToastTMP").GetComponent<Animator>();
        toastText = GameObject.Find("ToastTMP").GetComponent<TextMeshProUGUI>();
        anim.SetBool("Toast", false);

    }
	
	// Update is called once per frame
	void Update () {

        Check();

        if (isHatSold == 1)
            hat.SetActive(true);
        else
            hat.SetActive(false);

        moneyAmount = PlayerPrefs.GetInt("score");
		moneyText.text = "You have: " + moneyAmount.ToString() + "$";

        if (Input.GetKeyDown(KeyCode.P))
        {
            on = !on;
        }

        if (on)
        {
            shopItem.SetActive(true);
        }
        else
        {
            shopItem.SetActive(false);

        }

    }

    public void speed(){
        player.speed += 50;
        moneyAmount -= 20;
        PlayerPrefs.SetInt("score", moneyAmount);
        s.score = moneyAmount;
        toastText.text = "Bought succesfully +50 speed";
        anim.SetBool("Toast", true);
        Invoke("toastTime", 0.6f);
    }

    public void damage(){
        attackTrigger.damage += 10;
        moneyAmount -= 40;
        PlayerPrefs.SetInt("score", moneyAmount);
        s.score = moneyAmount;
        toastText.text = "Bought succesfully +10 damage";
        anim.SetBool("Toast", true);
        Invoke("toastTime", 0.6f);
    }

    public void jump(){
        player.jumpPow += 30;
        moneyAmount -= 20;
        isHatSold = 1;
        hatButton.gameObject.SetActive (false);
        PlayerPrefs.SetInt("score", moneyAmount);
        s.score = moneyAmount;
        toastText.text = "Bought succesfully +30 jump";
        anim.SetBool("Toast", true);
        Invoke("toastTime", 0.6f);
    }

    public void heart(){
        player.ourHealth += 1;
        moneyAmount -= 20;
        PlayerPrefs.SetInt("score", moneyAmount);
        s.score = moneyAmount;
        toastText.text = "Bought succesfully +1 heart";
        anim.SetBool("Toast", true);
        Invoke("toastTime", 0.6f);
    }

    void toastTime()
    {
        toastText.text = "";
        anim.SetBool("Toast", false);
    }

    void Check()
    {
        if (moneyAmount >= 20 && isHatSold == 0)
			hatButton.interactable = true;
		else
			hatButton.interactable = false;	

		if (moneyAmount >= 20){
			shoeButton.interactable = true;
            heartButton.interactable = true;
        }
		else{
			shoeButton.interactable = false;
            heartButton.interactable = false;
        }
        
		if (moneyAmount >= 40)
			swordButton.interactable = true;

		else
			swordButton.interactable = false;

    }

}