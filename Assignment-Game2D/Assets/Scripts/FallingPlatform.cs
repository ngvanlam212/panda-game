using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour{

    public Rigidbody2D r2d;
    public float timeDelay = 1;

    void Start(){
        r2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player")){
            StartCoroutine(fall());
        }
    }

    IEnumerator fall(){
        yield return new WaitForSeconds(timeDelay);
        r2d.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }

}
