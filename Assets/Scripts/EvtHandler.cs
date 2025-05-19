using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EvtHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
    IPointerUpHandler, IPointerDownHandler
{
    private Image _img;

    public Action<PointerEventData> PointEnter;
    public Action<PointerEventData> PointExit;
    public Action<PointerEventData> PointClickUp;
    public Action<PointerEventData> PointClickDown;

    private Sequence _sq;

    [SerializeField] private Color _normal;
    [SerializeField] private Color _enterColor;
    [SerializeField] private Color _clickDown;


    private void Awake()
    {
        _img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(_img.DOColor(_enterColor, 0.2f));

        PointEnter?.Invoke(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(_img.DOColor(_normal, 0.2f));

        PointExit?.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(_img.DOColor(_enterColor, 0.2f));

        PointClickUp?.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();

        _sq.Append(_img.DOColor(_clickDown, 0.2f));

        PointClickDown?.Invoke(eventData);
    }
}