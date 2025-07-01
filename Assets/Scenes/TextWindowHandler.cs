using UnityEngine;
using UnityEngine.UI;

public class TextWindowController : MonoBehaviour
{
    public GameObject textWindow; // Ссылка на Panel с окном текста
    public Text textComponent; // Ссылка на Text
    public Button openButton; // Ссылка на кнопку, которая открывает окно
    public Button closeButton; // Ссылка на кнопку закрытия окна
    public string textToDisplay = "Здесь будет отображаться текст."; // Текст, который нужно отобразить

    private void Start()
    {
        // Убедитесь, что окно скрыто при запуске (если вдруг не было выключено в редакторе)
        textWindow.SetActive(false);

        // Подписываемся на события нажатия кнопок
        openButton.onClick.AddListener(OpenTextWindow);
        closeButton.onClick.AddListener(CloseTextWindow);

        // Устанавливаем текст при старте (можно и в OpenTextWindow, если текст меняется)
        textComponent.text = textToDisplay;
    }

    public void OpenTextWindow()
    {
        textWindow.SetActive(true);
        // Если текст меняется динамически, можно обновлять его здесь
        // textComponent.text = GetTextFromSomewhere();
    }

    public void CloseTextWindow()
    {
        textWindow.SetActive(false);
    }

     // Пример функции для получения текста из другого источника (замените своим кодом)
    /*
    private string GetTextFromSomewhere()
    {
        // Здесь можно получить текст из файла, базы данных, API и т.д.
        return "Новый текст для отображения!";
    }
    */
}