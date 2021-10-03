
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Button button = null;

    private void Start()
    {
        if (!button)
            button = GetComponent<Button>();
    }


    // public void OnPointerEnter()
    // {
    // }
    //
    // public void OnPointerExit()
    // {
    // }

    public void OnPointerClick()
    {
        button.onClick.Invoke();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
