using UnityEngine;
using TMPro;
using System.Collections;

public class SubtitleManager : MonoBehaviour
{
    public Transform playerHead;
    public TextMeshPro subtitleText;
    [SerializeField] float timeBetweenChars;
    [SerializeField] float timeBetweenWords;
    [SerializeField] float displayDuration; // Время отображения субтитров
    [SerializeField] float startDelay; // Задержка перед началом субтитров

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

        // Начинаем проигрывание субтитров с задержкой
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
            // Отображаем текущий субтитр
            subtitleText.text = stringArray[subtitleIndex].Substring(0, charIndex);

            // Увеличиваем индекс символа для следующего кадра
            charIndex++;

            // Ждем перед отображением следующего символа
            yield return new WaitForSeconds(timeBetweenChars);

            // Если мы отобразили все символы в текущем субтитре, переходим к следующему
            if (charIndex > stringArray[subtitleIndex].Length)
            {
                subtitleIndex++;
                charIndex = 0;

                // Ждем перед отображением следующего субтитра
                yield return new WaitForSeconds(timeBetweenWords);

                // Сбрасываем таймер отображения при переходе к следующему субтитру
                displayTimer = 0f;
                subtitlesVisible = true;
            }
        }

        // Субтитры закончились, ожидаем перед скрытием
        yield return new WaitForSeconds(displayDuration);
        HideSubtitles();
    }

    void Update()
    {
        // Если субтитры начались, обновляем таймер отображения
        if (subtitlesStarted)
        {
            UpdateSubtitlePositionAndRotation();

            // Если субтитры отображаются, увеличиваем таймер отображения
            if (subtitlesVisible)
            {
                displayTimer += Time.deltaTime;

                // Если таймер превысил время отображения, скрываем субтитры
                if (displayTimer > displayDuration)
                {
                    HideSubtitles();
                }
            }
        }
    }

    void UpdateSubtitlePositionAndRotation()
    {
        // Позиция субтитров перед глазами игрока
        Vector3 subtitlePosition = playerHead.position + playerHead.forward * 2f + Vector3.up * 2f + playerHead.right * 1f;

        // Устанавливаем позицию субтитров
        transform.position = Vector3.Lerp(transform.position, subtitlePosition, Time.deltaTime * 5f);

        // Поворот субтитров в сторону игрока
        Vector3 lookAtPosition = playerHead.position + playerHead.forward * 1000f;
        transform.LookAt(lookAtPosition);

        // Установка фиксированного размера субтитров
        subtitleText.fontSize = 8; 
    }

    void HideSubtitles()
    {
        // Скрываем субтитры
        subtitleText.text = "";
        subtitlesVisible = false;
    }
}
