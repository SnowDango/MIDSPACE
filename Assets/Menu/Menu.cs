using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject text = GameObject.Find("Text");
        text.GetComponent<Text>().color = Color.magenta;
        text.GetComponent<Text>().text = "Please Enter";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("MIDSPACE");
        }
    }
}
