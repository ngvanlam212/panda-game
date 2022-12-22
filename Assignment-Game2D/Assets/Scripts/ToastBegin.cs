using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastBegin : MonoBehaviour
{
    private bool toast = false;
    public GameObject toastUI;
    // Start is called before the first frame update
    void Start()
    {
        toastUI.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            toastUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        toastUI.SetActive(false);
    }

}
