using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaineMenu : MonoBehaviour
{

    [SerializeField] Button newGameButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button BackButton;
    [SerializeField] Button OptionsButton;


    [SerializeField] GameObject MainMenuObj;
    [SerializeField] GameObject OptionsObj;

    private void Start()
    {
        newGameButton.onClick.AddListener(TransitionToNewScene);
        quitButton.onClick.AddListener(QuitGame);
        OptionsButton.onClick.AddListener(OpenOptions);
        BackButton.onClick.AddListener(CloseOption);
    }




    void TransitionToNewScene() => SceneManager.LoadScene(2);
    void QuitGame() => Application.Quit();




    void OpenOptions()
    {
        MainMenuObj.SetActive(false);
        OptionsObj.SetActive(true);
    }
    void CloseOption()
    {
        MainMenuObj.SetActive(true);
        OptionsObj.SetActive(false);
    }
}
