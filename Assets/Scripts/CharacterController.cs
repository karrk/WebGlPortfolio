using DG.Tweening;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Vector2 _initPos;
    [SerializeField] private Vector2 _centerPos;

    private Sequence _sq;

    private void Start()
    {
        _initPos = transform.position;
    }

    public Sequence MoveCenter()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(transform.DOMove(_centerPos, 0.4f));

        return _sq;
    }

    public Sequence MoveInitPos()
    {
        _sq?.Kill();

        _sq = DOTween.Sequence();
        _sq.Append(transform.DOMove(_initPos, 0.4f));

        return _sq;
    }
}
