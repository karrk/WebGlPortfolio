using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    [SerializeField] private Vector2 _showPos;
    [SerializeField] private Vector2 _hidePos;

    private Sequence _sq;

    private void Start()
    {
        _showPos = transform.position;
    }

    public void Show()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(transform.DOMove(_showPos, 0.3f));
    }

    public void Hide()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(transform.DOMove(_hidePos, 0.3f));
    }

}
