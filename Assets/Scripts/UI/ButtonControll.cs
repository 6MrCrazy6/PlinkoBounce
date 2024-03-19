using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControll : MonoBehaviour
{
    public AudioClip transitionSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BackToMenu()
    {
        if (transitionSound != null && audioSource != null)
        {
            audioSource.clip = transitionSound;
            audioSource.Play();

            StartCoroutine(LoadSceneAfterSound(transitionSound.length, "MainMenu"));
        }
        else
        {

            SceneManager.LoadScene("MainMenu");
        }
    }

    public void StartGame()
    {
        if (transitionSound != null && audioSource != null)
        {
            audioSource.clip = transitionSound;
            audioSource.Play();

            StartCoroutine(LoadSceneAfterSound(transitionSound.length, "Game"));
        }
        else
        {

            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator LoadSceneAfterSound(float soundLength, string sceneName)
    {
        yield return new WaitForSeconds(soundLength);
        SceneManager.LoadScene(sceneName);
    }
}
