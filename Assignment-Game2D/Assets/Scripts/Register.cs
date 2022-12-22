using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Register : MonoBehaviour
{
    public InputField NAME;
    public InputField USERNAME;
    public InputField PASSWORD;

    string registerphp = "http://localhost/PHP/register.php";
    public void themMoi(){
        StartCoroutine(connect());
    }

    IEnumerator connect(){
        WWWForm wf = new WWWForm();
        wf.AddField("name_chuyen", NAME.text);
        wf.AddField("user_chuyen", USERNAME.text);
        wf.AddField("pass_chuyen", PASSWORD.text);

        WWW w = new WWW(registerphp, wf);
        yield return w;

        string tam = w.text;
        string tam1 = tam.TrimStart();
        string tam11 = tam1.TrimEnd();

        if (w.text == "Ngon")
        {
            StartLevel();
            print("Đăng ký thành công!");
        }else
        {
            print("Đăng ký thất bại!");
        }
        
    }

    public void StartLevel(){
        Application.LoadLevel("Login");
    }

    public void Back()
    {
        Application.LoadLevel("Login");
    }
}
