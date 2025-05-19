using DG.Tweening;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    private Sequence _sq;
    private Vector2 _initPos;

    private void Awake()
    {
        _initPos = transform.position;
    }

    public void SetPos(Vector2 m_pos)
    {
        _sq?.Kill();

        transform.DOMove(m_pos, 0.5f);
    }

    public void Hide()
    {
        _sq?.Kill();

        transform.DOMove(_initPos, 0.3f);
    }

}
