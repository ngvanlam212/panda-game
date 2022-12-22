using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningBegin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = 0.5f;
        transform.Translate(- Time.deltaTime * -time, 0, 0);
    }
}
