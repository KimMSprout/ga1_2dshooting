using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;

    private int _bestScore = 0;
    private int _currentScore = 0;
    private int _lastRefreshScore = -1;

    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        _instance = this;
    }

    public int GetScore()
    {
        return _currentScore;
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;

        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
    }

    private void Update()
    {
        Refresh();
    }

    private void Refresh()
    {
        // 매 프레임이 아닌, 적을 처치했을 때만 UI를 다시 그리도록 지정
        if (_lastRefreshScore == _currentScore) return;

        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";

        _lastRefreshScore = _currentScore;
    }
}