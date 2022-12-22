using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCloud : MonoBehaviour
{
    public GameObject doiTuong;
    public GameObject viTri;
    // Start is called obefore the first frame update
    void Start()
    {
        StartCoroutine(connect());
    }

    void Update(){

        //StartCoroutine(delay());

    }
    // Update is called once per frame
    IEnumerator connect(){
        yield return new WaitForSeconds(2);
        Vector3 tam = viTri.transform.position;
        tam.x = Random.Range(7f, 65f);
        tam.y = Random.Range(4.5f, 5.5f);
        Instantiate(doiTuong, tam, Quaternion.identity);
        StartCoroutine(connect());
        //StartCoroutine(delay());
    }

    //IEnumerator delay()
    //{
    //    yield return new WaitForSeconds(3);
    //    Destroy(doiTuong);
    //}

}
