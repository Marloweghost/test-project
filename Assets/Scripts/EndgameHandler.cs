using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameHandler : MonoBehaviour
{
    [SerializeField] private GameObject _loseImageObject;
    [SerializeField] private GameObject _winImageObject;
    [SerializeField] private EnemiesRemainingUI _enemiesRemainingUI;
    [SerializeField] private float _winDelayTime;
    [SerializeField] private float _loseDelayTime;

    public static EndgameHandler instance = null;

    public enum GameState
    {
        Win,
        Loss
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Initialize(GameState gameState)
    {
        _enemiesRemainingUI.Deactivate();

        switch (gameState)
        {
            case GameState.Win:
                StartCoroutine(LaunchWinDelay());
                break;
            case GameState.Loss:
                StartCoroutine(LaunchLoseDelay());
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator LaunchWinDelay()
    {
        yield return new WaitForSeconds(_winDelayTime);
        _winImageObject.SetActive(true);
    }

    private IEnumerator LaunchLoseDelay()
    {
        yield return new WaitForSeconds(_loseDelayTime);
        _loseImageObject.SetActive(true);
    }
}
