using UnityEngine;
using UnityEngine.UI;

public class TextWindowController : MonoBehaviour
{
    public GameObject textWindow; // ������ �� Panel � ����� ������
    public Text textComponent; // ������ �� Text
    public Button openButton; // ������ �� ������, ������� ��������� ����
    public Button closeButton; // ������ �� ������ �������� ����
    public string textToDisplay = "����� ����� ������������ �����."; // �����, ������� ����� ����������

    private void Start()
    {
        // ���������, ��� ���� ������ ��� ������� (���� ����� �� ���� ��������� � ���������)
        textWindow.SetActive(false);

        // ������������� �� ������� ������� ������
        openButton.onClick.AddListener(OpenTextWindow);
        closeButton.onClick.AddListener(CloseTextWindow);

        // ������������� ����� ��� ������ (����� � � OpenTextWindow, ���� ����� ��������)
        textComponent.text = textToDisplay;
    }

    public void OpenTextWindow()
    {
        textWindow.SetActive(true);
        // ���� ����� �������� �����������, ����� ��������� ��� �����
        // textComponent.text = GetTextFromSomewhere();
    }

    public void CloseTextWindow()
    {
        textWindow.SetActive(false);
    }

     // ������ ������� ��� ��������� ������ �� ������� ��������� (�������� ����� �����)
    /*
    private string GetTextFromSomewhere()
    {
        // ����� ����� �������� ����� �� �����, ���� ������, API � �.�.
        return "����� ����� ��� �����������!";
    }
    */
}