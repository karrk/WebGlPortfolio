using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private Vector2 _initPos;
    [SerializeField] private Vector2 _centerPos;

    private Sequence _sq;

    // Start is called before the first frame update
    void Start()
    {
        _initPos = transform.position;
    }

    public Sequence MoveCenterPos()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(transform.DOMove(_centerPos, 2f)).SetEase(Ease.Linear);

        return _sq;
    }

    public Sequence MoveInitPos()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(transform.DOMove(_initPos, 2f)).SetEase(Ease.Linear);

        return _sq;
    }
}
