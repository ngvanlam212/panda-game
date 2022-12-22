using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float lifeTime = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(- Time.deltaTime * 3, 0, 0);
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        //StartCoroutine(delay());
    }

    //IEnumerator delay()
    //{
    //    yield return new WaitForSeconds(11);
    //    Destroy(gameObject);
    //}
}
