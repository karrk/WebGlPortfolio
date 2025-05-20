using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QnAPage : MonoBehaviour
{
    private RectTransform RT;

    [SerializeField] private Button _closeBtn;

    [SerializeField] private LeftHand _lh;

    private Sequence _sq;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        _closeBtn.onClick.AddListener(Close);
    }

    public void Show()
    {
        _sq?.Kill(); 

        _sq = DOTween.Sequence();
        _sq.Append(RT.DOPivotX(0, 0));
        _sq.Append(RT.DOPivotX(1, 0.25f));
    }

    public void Close()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(RT.DOPivotX(0, 0.25f));
        _sq.OnComplete(() =>
        {
            _lh.Show(); // 따로빼기
            this.gameObject.SetActive(false);
        });
    }

    public void StartAnswer(int m_qnaIdx)
    {
        Speaker.Instance.ShowBubbleText(m_qnaIdx);
    }

    public void BtnClickActive(bool m_active)
    {
        foreach (var btn in GetComponentsInChildren<Button>())
        {
            btn.interactable = m_active;
        }
    }
}
