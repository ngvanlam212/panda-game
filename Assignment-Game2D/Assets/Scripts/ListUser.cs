using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ListUser : MonoBehaviour
{

    public GameObject rowNew;
    string URL = "http://localhost/PHP/showuser.php";

    // Start is called before the first frame update
    void Start()
    {
        getData();
    }

    public void getData(){
        StartCoroutine(connect());
    }

    IEnumerator connect(){
        WWWForm wf = new WWWForm();
        WWW w = new WWW(URL, wf);
        yield return w;
        string data = w.text;
        
        //Khai báo biến lưu trữ
        string[] a = new string[]{};
        a = data.Split(',');

        for (int i = 0; i < (a.Length)-1; i++)
        {
            string dong = a[i];
            string[] b = new string[]{};
            b = dong.Split('-');

            GameObject gameObject = (GameObject)Instantiate(rowNew);
            gameObject.transform.SetParent(this.transform);
            gameObject.transform.Find("id").GetComponent<Text>().text = b[0];
            gameObject.transform.Find("name").GetComponent<Text>().text = b[1];
            gameObject.transform.Find("score").GetComponent<Text>().text = b[2];
            gameObject.transform.Find("username").GetComponent<Text>().text = b[3];
            gameObject.transform.Find("password").GetComponent<Text>().text = b[4];

        }

    }

    public void Back()
    {
        Application.LoadLevel("Begin");
    }

}
