using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    private LeftHand _lh;
    [SerializeField] private RightHand _rh;
    
    [SerializeField] private EvtHandler _qnaBtn;
    [SerializeField] private EvtHandler _careerBtn;
    [SerializeField] private EvtHandler _portfolioBtn;
    [SerializeField] private EvtHandler _jjBtn;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private GameObject _qnaPage;
    [SerializeField] private GameObject _careerPage;

    private Sequence _delaySq;

    private void Start()
    {
        _lh = GetComponentInParent<LeftHand>();

        _qnaBtn.PointEnter += Enterqna;
        _careerBtn.PointEnter += Entercareer;
        _portfolioBtn.PointEnter += Enterportfolio;

        _qnaBtn.PointExit += ExitBtn;
        _careerBtn.PointExit += ExitBtn;
        _portfolioBtn.PointExit += ExitBtn;

        _qnaBtn.PointClickUp += QnaClickUp;
    }

    private void QnaClickUp(PointerEventData m_data)
    {
        _lh.Hide();
        _rh.Hide();

        _qnaPage.SetActive(true);
    }

    private void ExitBtn(PointerEventData m_data)
    {
        _delaySq?.Kill();

        _delaySq = DOTween.Sequence();
        _delaySq.AppendInterval(1f);
        _delaySq.OnComplete(() => _rh.Hide());
    }

    private void Enterqna(PointerEventData m_data)
    {
        _delaySq?.Kill();
        _rh.SetPos(_qnaBtn.transform.position + _offset);
    }

    private void Entercareer(PointerEventData m_data)
    {
        _delaySq?.Kill();
        _rh.SetPos(_careerBtn.transform.position + _offset);
    }

    private void Enterportfolio(PointerEventData m_data)
    {
        _delaySq?.Kill();
        _rh.SetPos(_portfolioBtn.transform.position + _offset);
    }
}

