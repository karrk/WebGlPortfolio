using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    private RectTransform RT;
    private Sequence _sq;

    [SerializeField] private Button _qna;
    [SerializeField] private Button _introduce;
    [SerializeField] private Button _career;
    [SerializeField] private Button _portfolio;

    [SerializeField] private GameObject _qnaPage;
    [SerializeField] private GameObject _introducePage;
    [SerializeField] private GameObject _careerPage;
    [SerializeField] private GameObject _portfolioPage;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
        DOTween.Init(false, false, LogBehaviour.Default).SetCapacity(100, 20);
    }

    private void OnEnable()
    {
        Show();
    }

    private void Show()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(RT.DOPivotX(0, 0));
        _sq.Append(RT.DOPivotX(1, 0.25f));
    }

    private void Close(GameObject m_nextPage)
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(RT.DOPivotX(0, 0.25f));
        _sq.OnComplete(() =>
        {
            m_nextPage.SetActive(true);
            this.gameObject.SetActive(false);
        });
    }

    private void Start()
    {
        _qna.onClick.AddListener(OpenQnA);
        _introduce.onClick.AddListener(OpenIntroduce);
        _career.onClick.AddListener(OpenCareer);
        _portfolio.onClick.AddListener(OpenPortfolio);
    }

    private void OpenQnA()
    {
        Close(_qnaPage);
    }
    private void OpenIntroduce()
    {
        Close(_introducePage);
    }
    private void OpenCareer()
    {
        Close(_careerPage);
    }
    private void OpenPortfolio()
    {
        Close(_portfolioPage);
    }
}
