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
        _comBtn.onClick.AddListener(StartAnswer);
    }

    private void Show()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(RT.DOPivotX(0, 0));
        _sq.Append(RT.DOPivotX(1, 0.25f));
    }

    private void Close()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(RT.DOPivotX(0, 0.25f));
        _sq.OnComplete(() =>
        {
            _lh.Show();
            this.gameObject.SetActive(false);
        });
    }

    [SerializeField] private Button _comBtn;

    private void StartAnswer()
    {
        Speaker.Instance.ShowBubbleText(0);
    }
}
