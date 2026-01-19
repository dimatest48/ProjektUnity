using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private Player _player;
    [SerializeField] private TileGenerator _tileGenerator;
    [SerializeField] private float _loadDelay = 4;

    [SerializeField] private AudioClip _coinSound;
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private AudioSource _audioSource;
    private int _coinsCount;
    void Start()
    {
        _player.DieEvent.AddListener(LoseHandler);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void LoseHandler()
    {
        print("Koniec gry");
        _audioSource.PlayOneShot(_explosionSound);
        SaveScore();
        _tileGenerator.SetEnabling(false);
        StartCoroutine(LoadDelayedMenu());
    }

    private IEnumerator LoadDelayedMenu()
    {
        yield return new WaitForSeconds(_loadDelay);
        SceneManager.LoadScene("Menu");
    }

    private void SaveScore()
    {
        int oldScore = PlayerPrefs.GetInt("score");

        if(oldScore < _coinsCount)
        {
            PlayerPrefs.SetInt("score", _coinsCount);
            PlayerPrefs.Save();
        }

        
    }

    public void AddCoin()
    {
        _coinsCount++;
        _coinsText.text = _coinsCount.ToString();

        _audioSource.PlayOneShot(_coinSound);
    }
}
