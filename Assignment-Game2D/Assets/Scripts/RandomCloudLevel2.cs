using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloudLevel2 : MonoBehaviour
{
    public GameObject doiTuong;
    public GameObject viTri;
    // Start is called obefore the first frame update
    void Start()
    {
        StartCoroutine(connect());
        // StartCoroutine(delay());
    }

    // Update is called once per frame
    IEnumerator connect(){
        yield return new WaitForSeconds(3);
        Vector3 tam = viTri.transform.position;
        tam.x = Random.Range(12f, 45f);
        tam.y = Random.Range(-1.5f, 1f);
        Instantiate(doiTuong, tam, Quaternion.identity);
        StartCoroutine(connect());
    }

    // IEnumerator delay(){
    //     yield return new WaitForSeconds(6);
    //     Destroy(gameObject);
    // }
}
