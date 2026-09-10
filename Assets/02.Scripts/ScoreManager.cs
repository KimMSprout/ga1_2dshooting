using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _bestScore = 0;
    private int _currentScore = 0;

    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;

    private void Update()
    {
        _bestScoreTextUI.text = _bestScore.ToString();
        _currentScoreTextUI.text = _currentScore.ToString();
    }
}