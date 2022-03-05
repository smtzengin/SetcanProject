using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float delayLevelTime = 1f;
    [SerializeField] public int score;

    public static GameManager Instance { get; private set; }
    public int buildIndex;

    public event System.Action<bool> OnSceneChanged;
    public event System.Action<int> OnScoreChanged;

    private void Awake()
    {
        SingletonGameObject();
    }

    private void SingletonGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadScene(int levelIndex = 0)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }
    private IEnumerator LoadSceneAsync(int levelIndex)
    {
        yield return new WaitForSeconds(delayLevelTime);

        buildIndex = SceneManager.GetActiveScene().buildIndex;

        print(buildIndex);

        yield return SceneManager.UnloadSceneAsync(buildIndex);

        SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
        };

        OnSceneChanged?.Invoke(false);
    }


    public void LoadMenuAndUi(float delayLoadingTime)
    {
        StartCoroutine(LoadMenuAndUiAsync(delayLoadingTime));

    }

    private IEnumerator LoadMenuAndUiAsync(float delayLoadingTime)
    {
        yield return new WaitForSeconds(delayLoadingTime);
        yield return SceneManager.LoadSceneAsync("Menu");
        yield return SceneManager.LoadSceneAsync("Ui", LoadSceneMode.Additive);

        OnSceneChanged?.Invoke(true);
        IncreaseScore();
    }

    public void ExitGame()
    {
        Debug.Log("Exit button triggered");
        Application.Quit();
    }

    public void IncreaseScore(int score = 0)
    {
        this.score += score;
        OnScoreChanged?.Invoke(this.score);
    }
}
