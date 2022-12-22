using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject destroyEffect;
    public Rigidbody2D r2;

    public HealthBarBehavior healthBarBehavior;
    private SpriteRenderer spriteRend;
    public AudioClip vacham;

    public Player player;
    public int ourHealth;
    public int ourMaxHealth = 100;
    public Score s;
    bool isInvincible;

    void Start()
    {
         r2 = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        ourHealth = ourMaxHealth;
        healthBarBehavior.SetHealth(ourHealth, ourMaxHealth);
         spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (ourHealth <= 0)
        {
            s.score += 5;
            GameControl.moneyAmount += 5;
            PlayerPrefs.SetInt("score", GameControl.moneyAmount);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    public void Invincible(bool invincibility) {
        isInvincible = invincibility;
    }

    private void OnTriggerStay2D(Collider2D collider2D)
    {

        if (collider2D.CompareTag("Player"))
        {
            player.HitSide(transform.position.x > player.transform.position.x);
            player.Damage(1);
        }

    }


    void Damage(int damage)
    {
        // float hitForceX = 3.0f;
        //         float hitForceY = 2.0f;
        //          if (transform.position.x < player.transform.position.x) hitForceX = -hitForceX;
        //         r2.velocity = Vector2.zero;
        //         r2.AddForce(new Vector2(hitForceX, hitForceY), ForceMode2D.Impulse);
        SoundManager.Instance.Play(vacham);
        ourHealth -= damage;
        StartCoroutine(afterDamage());
        healthBarBehavior.SetHealth(ourHealth, ourMaxHealth);
    }

    private IEnumerator afterDamage() {
          spriteRend.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(0.15f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.15f);
    }
}
