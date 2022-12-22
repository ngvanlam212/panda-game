using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
 
public class Attack : MonoBehaviour {
    public float attackDelay = 0.5f;
    public bool attacking = false;
    
    public Animator anim;
 
    public Collider2D trigger;

    public Button attackButton;

    public AudioClip attackingClip;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;
    }
 
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackDelay = 0.5f;
        }
 
        if (attacking)
        {
            SoundManager.Instance.Play(attackingClip);
            if (attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
 
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
 
        anim.SetBool("Attacking", attacking);
    }

    public void attack()
    {
        if (!attacking)
        {
            attacking = true;
            trigger.enabled = true;
            attackDelay = 0.5f;
        }
        
    }
}