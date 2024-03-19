using System.Collections;
using UnityEngine;

public class FinishControll : MonoBehaviour
{
    public float scaleFactor = 0.9f;
    public float animationDuration = 0.1f;

    public AudioClip mySoundClip;

    private Vector2 originalSize;

    private AudioSource audioSource;
    private RectTransform rectTransform;

    void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;

        audioSource = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PlayAnimationAndSound());
        }
    }

    IEnumerator PlayAnimationAndSound()
    {
        yield return StartCoroutine(ScaleObject(originalSize * scaleFactor));

        if (mySoundClip != null)
        {
            audioSource.clip = mySoundClip;
            audioSource.Play();
        }

        yield return StartCoroutine(ScaleObject(originalSize));
    }

    IEnumerator ScaleObject(Vector2 targetSize)
    {
        Vector2 startSize = rectTransform.sizeDelta;
        float timer = 0f;

        while (timer < animationDuration)
        {
            rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, timer / animationDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        rectTransform.sizeDelta = targetSize;
    }
}
