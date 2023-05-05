using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class login : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    // Start is called before the first frame update

    public void HandleLogin()
    {
        string user = username.text;
        string pswd = password.text;
        if (user == "admin" && pswd == "open")
        {
            SceneManager.LoadScene("Application");
        }
    }

}
