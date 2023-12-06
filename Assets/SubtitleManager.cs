using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleManager : MonoBehaviour
{
    public Transform playerHead;
    public TextMeshPro subtitleText;
    [SerializeField] float timeBetweenChars;
    [SerializeField] float timeBetweenWords;
    [SerializeField] float displayDuration;
    [SerializeField] float startDelay;
    [SerializeField] float distance = 2f;
    [SerializeField] float height = 1f;
    [SerializeField] float offset = 3f;
    
    [SerializeField]
    public string[] stringArray;

    int subtitleIndex = 0;
    int charIndex = 0;
    bool subtitlesVisible = false;
    float displayTimer = 0f;
    bool subtitlesStarted = false;

    void Start()
    {
        if (subtitleText == null)
        {
            subtitleText = GetComponent<TextMeshPro>();
        }

        if (playerHead == null)
        {
            playerHead = Camera.main.transform;
        }

        StartCoroutine(StartSubtitles());
    }

    IEnumerator StartSubtitles()
    {
        yield return new WaitForSeconds(startDelay);
        subtitlesStarted = true;
        StartCoroutine(PlaySubtitles());
    }

    IEnumerator PlaySubtitles()
    {
        while (subtitleIndex < stringArray.Length)
        {
            subtitleText.text = stringArray[subtitleIndex].Substring(0, charIndex);
            charIndex++;

            yield return new WaitForSeconds(timeBetweenChars);

            if (charIndex > stringArray[subtitleIndex].Length)
            {
                subtitleIndex++;
                charIndex = 0;

                yield return new WaitForSeconds(timeBetweenWords);

                displayTimer = 0f;
                subtitlesVisible = true;
            }
        }

        yield return new WaitForSeconds(displayDuration);
        HideSubtitles();
    }

    void LateUpdate()
    {
        if (subtitlesStarted)
        {
            UpdateSubtitlePositionAndRotation();
        }
    }

    void UpdateSubtitlePositionAndRotation()
    {
        float interpolationSpeed = 5f;

        Vector3 subtitlePosition = playerHead.position + playerHead.forward * distance + Vector3.up * height + playerHead.right * offset;
        transform.position = Vector3.Lerp(transform.position, subtitlePosition, Time.deltaTime * interpolationSpeed);

        Vector3 lookAtPosition = playerHead.position + playerHead.forward * 1000f;
        transform.LookAt(lookAtPosition);

        subtitleText.fontSize = 8; 
    }

    void HideSubtitles()
    {
        subtitleText.text = "";
        subtitlesVisible = false;
    }
}
