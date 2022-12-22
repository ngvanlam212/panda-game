using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public Animator anim;
    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.isTrigger != true && collider2D.CompareTag("Enemy"))
        {
            anim = gameObject.GetComponent<Animator>();
            collider2D.SendMessageUpwards("Damage", damage);
        }
    }

}