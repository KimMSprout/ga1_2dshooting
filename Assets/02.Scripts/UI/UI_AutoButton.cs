using UnityEngine;
using UnityEngine.UI;

public class UI_AutoButton : MonoBehaviour
{
    // 버튼을 클릭하면 토글
    // - 플레리어의 자동 이동
    // - 플레이어의 자동 공격

    [Header("on/off 스프라이트")]
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private Image _myImage;
    private bool _autoMode = false;
    private Player _player;

    void Start()
    {
        _player = GameObject.FindAnyObjectByType<Player>();
        _myImage = GetComponent<Image>();

        AutoToggle();
    }

    public void AutoToggle()
    {
        _autoMode = !_autoMode;

        _player.GetComponent<PlayerFire>().SetAuto(_autoMode);
        _player.GetComponent<PlayerMove>().enabled = !_autoMode;
        _player.GetComponent<PlayerAutoMove>().enabled = _autoMode;

        _myImage.sprite = _autoMode ? _onSprite : _offSprite;
    }

    //TODO: 버틍 클릭할 떄 애니메이션 주기 + 사운드 주기
    // 애니메이션 컴포넌트 : UI_ButtonClick
    // 애니메이션 : 코드로 구현 약간 커졌다가 원래대로
    // 사운드: 일레븐 랩스에서 버튼 클릭 공용 사운드 만들어서 적용
}