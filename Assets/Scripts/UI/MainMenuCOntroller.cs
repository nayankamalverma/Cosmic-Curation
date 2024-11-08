using CosmicCuration.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Button start;
    [SerializeField]
    private Button instruction;
    [SerializeField]
    private Button close;
    [SerializeField]
    private Button exit;

    // instruction ui
    [SerializeField] private Image instructionUI;
    [SerializeField] private Button closeInstructionUI;


    private void Awake()
    {
        start.onClick.AddListener(StartGame);
        instruction.onClick.AddListener(ActiveInstrucionUI); 
        close.onClick.AddListener(DeactiveInstrucionUI);
        exit.onClick.AddListener(ExitGame);
    }


    private void StartGame()
    {
        SoundService.Instance.Play(SoundType.PlayerBullet);
        SceneManager.LoadScene(1);
    }

    private void ActiveInstrucionUI()
    {
        instructionUI.gameObject.SetActive(true);
    }
    private void DeactiveInstrucionUI()
    {
        instructionUI.gameObject.SetActive(false);
    }

    private void ExitGame()
    { 
        SoundService.Instance.Play(SoundType.PlayerBullet);
        Application.Quit();
    }
}
