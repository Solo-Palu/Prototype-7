using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load the best score display
        bestScoreText.text = $"Best Score: {DataManager.Instance.bestPlayerName} - {DataManager.Instance.bestScore}";

        // Set the input field with the last used name (if any)
        if (!string.IsNullOrEmpty(DataManager.Instance.playerName))
        {
        nameInputField.text = DataManager.Instance.playerName;
        }

        nameInputField.onEndEdit.AddListener(NewNameSelected);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void NewNameSelected(string name)
    {
        DataManager.Instance.playerName = name;
    }

    
}
