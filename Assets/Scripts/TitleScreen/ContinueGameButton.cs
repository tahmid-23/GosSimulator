using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class ContinueGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().interactable = PlayerPrefs.HasKey("CurrentScene");
    }

    public void onClick()
    {
        Setup.isSetup = false;
        NPCBase.uiSetupCompleted = false;
        SceneManager.LoadScene("Tutorial");
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
