using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Tower tower;
    [SerializeField] private CanvasGroup winScreenGroup;
    [SerializeField] private Button reloadButton;

    private void OnEnable()
    {
        tower.OnTowerDestroyed += OnTowerDestroyed;
        reloadButton.onClick.AddListener(OnReloadButtonClick);
    }

    private void OnDisable()
    {
        tower.OnTowerDestroyed -= OnTowerDestroyed;
        reloadButton.onClick.RemoveListener(OnReloadButtonClick);
    }

    private void OnTowerDestroyed()
    {
        winScreenGroup.alpha = 1f;
        winScreenGroup.interactable = true;
        Time.timeScale = 0f;
    }

    private void OnReloadButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
