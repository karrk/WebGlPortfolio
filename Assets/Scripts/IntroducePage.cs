using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class IntroducePage : MonoBehaviour
{
    private RectTransform RT;
    private Sequence _sq;

    [SerializeField] private Button _close;
    [SerializeField] private GameObject _prevPage;
    [SerializeField] private ScrollRect _scroll;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _scroll.verticalNormalizedPosition = 1f;
        Show();
    }

    private void Start()
    {
        _close.onClick.AddListener(Close);   
    }

    private void Show()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(RT.DOPivotY(-1, 0));
        _sq.Append(RT.DOPivotY(0, 0.25f));
    }

    private void Close()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(RT.DOPivotY(1, 0.25f));
        _sq.OnComplete(() =>
        {
            _prevPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }
}
