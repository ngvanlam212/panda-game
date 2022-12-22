using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Player : MonoBehaviour {

    public float speed = 50f, maxspeed = 3, jumpPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;
    
    public Rigidbody2D r2;
    public Animator anim;
    private SpriteRenderer spriteRend;

    bool isInvincible;
    bool hitSideRight;
 
    public int ourHealth;
    public int maxHealth;

    public Score s;


    void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        s = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        ourHealth = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.8f);
                }
            }
        }
    }

    void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    public void HitSide(bool rightSide)
    {
        // determines the push direction of the hit animation
        hitSideRight = rightSide;
    }

    public void Death(){
        anim.SetTrigger("PlayerDied");
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < s.score)
        PlayerPrefs.SetInt("highscore", s.score);
        PlayerPrefs.SetInt("score", 0);
    }

     public void Invincible(bool invincibility)
    {
        isInvincible = invincibility;
    }

    public void Damage(int damage){
        if (!isInvincible) {
            ourHealth -= damage;
            anim.SetTrigger("Hurt");
            if(ourHealth <= 0){
                Death();
            } else {
                  Invincible(true);
                float hitForceX = 2.0f;
                float hitForceY = 2.5f;
                 if (hitSideRight) hitForceX = -hitForceX;
                r2.velocity = Vector2.zero;
                r2.AddForce(new Vector2(hitForceX, hitForceY), ForceMode2D.Impulse);
                StartCoroutine(FlashAfterDamge());
            }
          
        }
       
    }

    private IEnumerator FlashAfterDamge() {
          // hit animation is 12 samples
        // keep flashing consistent with 1/12 secs
        for (int i = 0; i < 10; i++) {
            spriteRend.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.0833f);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(0.0833f);
        }
        Invincible(false);
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Gem")){
            Destroy(col.gameObject);
            s.score += 1;
            GameControl.moneyAmount += 1;
            PlayerPrefs.SetInt("score", GameControl.moneyAmount);

        }

        if(col.CompareTag("Cherry")){
            Destroy(col.gameObject);
            s.score += 2;
            GameControl.moneyAmount += 2;
            PlayerPrefs.SetInt("score", GameControl.moneyAmount);
       
        }

        if(col.CompareTag("Treasure")){
            Destroy(col.gameObject);
            s.score += 5;
            GameControl.moneyAmount += 5;
            PlayerPrefs.SetInt("score", GameControl.moneyAmount);
            print(GameControl.moneyAmount);

        }
        
        if(col.CompareTag("HealthRecovery")){
            Destroy(col.gameObject);
            ourHealth += 1;

        }

        if(col.CompareTag("Trap")){
           
            Death();
        }

        if (col.CompareTag("Water"))
        {
           
            Death();
        }

    }

}