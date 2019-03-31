using System.Collections;
using System.Collections.Generic;
using LooklingGlassShooting.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
    }

    public void ShowTitle()
    {
        SceneManager.LoadScene("title");
        Debug.Log("title");  
    }

    public void ShowCharacterSelect()
    {
        SceneManager.LoadScene("machineselect");
        Debug.Log("load");
    }

    public void CharactersSelected(SeasonFormat player1Season, SeasonFormat player2Season)
    {
        GlobalRegistory.SetSeasons(player1Season,player2Season);
        ShowBattle();
    }

    private void ShowBattle()
    {
        SceneManager.LoadScene("Battle");
    }
}
