using UnityEditor.Overlays;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private const string Upgradesavedata = "UpgradeSaveData";
    // 업그레이드 관리자 : 특정 데이터에 대한 무결성과 생성, 조회, 수정, 삭제 등과 관련된 게임 로직

    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    [SerializeField] private UI_Upgrade[] _uiUpgrades;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        Load();

        RefreshUI();
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = _upgrades[index];

        if (ScoreManager.Instance.GetScore() <= upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.SpendScore(upgrade.Cost);

        _upgrades[index].LevelUp();

        Save();

        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }

    private void Save()
    {
        // 데이터 저장은 유의미한 정보만 저장을 한다.

        // 그래서 레벨만 저장한다.

        UpgradeSaveData saveData = new UpgradeSaveData(_upgrades.Length);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            saveData.Name[i] = _upgrades[i].Name;
            saveData.Level[i] = _upgrades[i].Level;
        }

        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(Upgradesavedata, json);

        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(Upgradesavedata)) return;


        string json = PlayerPrefs.GetString(Upgradesavedata, string.Empty);

        if (json == string.Empty) return;

        UpgradeSaveData saveData = JsonUtility.FromJson<UpgradeSaveData>(json);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            _upgrades[i].SetLevel(saveData.Level[i]);
        }
    }
}