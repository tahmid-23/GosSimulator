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
        GetComponent<Button>().interactable = PlayerPrefs.HasKey("game_started");
    }

    public void onClick()
    {
        SceneManager.LoadScene("First Scene");
    }
}
