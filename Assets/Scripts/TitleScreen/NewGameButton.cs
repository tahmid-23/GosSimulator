using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void onClick()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
        PlayerPrefs.SetString("CurrentScene", "Tutorial");
    }
}
