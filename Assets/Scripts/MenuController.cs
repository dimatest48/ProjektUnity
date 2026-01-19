using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTextView;
    [SerializeField] private GameObject _exitButton;
    void Start()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        _exitButton.SetActive(true);
#elif UNITY_WEBGL
        _exitButton.SetActive(false);
#endif

        LoadScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void LoadScore()
    {
        int score = PlayerPrefs.GetInt("score");
        _scoreTextView.text = score.ToString();
    }
}
