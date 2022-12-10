using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContinueGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().interactable = PlayerPrefs.HasKey("CurrentScene");
    }

    public void onClick()
    {
        SceneManager.LoadScene("Tutorial");
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
