using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _bestScore = 0;
    private int _currentScore = 0;

    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;

    public int GetScore()
    {
        return _currentScore;
    }

    public void AddScore(int score)
    {
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
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Score: {_currentScore}";
    }
}