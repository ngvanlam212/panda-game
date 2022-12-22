using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    IEnumerator fadeOut()
    {
        for(float f = 1f; f >= -0.05; f -= 0.05f){
            Color col = renderer.material.color;
            col.a = f;
            renderer.material.color = col;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void startFading()
    {
        StartCoroutine(fadeOut());
    }

}
