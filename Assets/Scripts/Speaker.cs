using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Speaker : MonoBehaviour
{
    private static Speaker _instance;
    public static Speaker Instance => _instance;

    private Image _mainRay;
    private Button _btn;

    private string _address = "https://docs.google.com/spreadsheets/d/1UEP8KbWbf3lSReyBQqmND1xHSNpC9jEB2oMsT16EIq0";
    private string _loadRange = "B1:H5";
    private string _id = "0";

    [SerializeField] private Image _bubble;
    [SerializeField] private TMP_Text _tmp;

    [SerializeField] private GameObject _clickAnim;

    private List<List<string>> _datas = new List<List<string>>();

    private Sequence _sq;

    [SerializeField] private QnAPage _qnaPage;
    [SerializeField] private CharacterController _character;
    [SerializeField] private BackGroundController _background;

    private int _currentAnswer = -1;
    private int _currentStep = 0;

    private void Awake()
    {
        _btn = GetComponent<Button>();
        _mainRay = GetComponent<Image>();
        _instance = this;
        _mainRay.raycastTarget = false;
        _btn.interactable = false;
    }

    private void Start()
    {
        _btn.onClick.AddListener(ShowNextAnswer);
        StartCoroutine(LoadData());
    }

    private string GetCSVAddress(string m_address, string m_range, string m_id)
    {
        return $"{m_address}/export?format=tsv&range={m_range}&gid={m_id}";
    }

    private IEnumerator LoadData()
    {
        UnityWebRequest www = UnityWebRequest.Get(GetCSVAddress(_address, _loadRange, _id));
        yield return www.SendWebRequest();

        string[] texts = www.downloadHandler.text.Split('\n');

        for (int i = 0; i < texts.Length; i++)
        {
            List<string> tempList = new List<string>();

            _datas.Add(tempList);

            string[] innerData = texts[i].Split('\t');

            for (int j = 0; j < innerData.Length; j++)
            {
                if (innerData[j].Length <= 1)
                    break;

                tempList.Add(innerData[j]);
            }
        }
    }

    //n 번째 인덱스 질문에 대한 답변
    public void ShowBubbleText(int m_idx)
    {
        if (_currentAnswer == -1)
        {
            _currentAnswer = m_idx;
            _currentStep = 0;
            _character.MoveCenter();
            _qnaPage.BtnClickActive(false);
            _qnaPage.Close();
            _background.MoveCenterPos();
        }

        _sq?.Kill();

        _mainRay.raycastTarget = false;
        _btn.interactable = false;
        _bubble.gameObject.SetActive(true);
        _tmp.text = "";
        
        _sq = DOTween.Sequence();

        _sq.Append(_tmp.DOText(_datas[m_idx][_currentStep], _datas[m_idx][_currentStep].Length * 0.04f).SetEase(Ease.Linear));
        _sq.OnComplete(() =>
        {
            _currentStep++;
            _mainRay.raycastTarget = true;
            _btn.interactable = true;
            _clickAnim.SetActive(true);
        });
    }

    private void ShowNextAnswer()
    {
        _btn.interactable = false;
        _mainRay.raycastTarget = false;
        _clickAnim.gameObject.SetActive(false);

        // 다음 데이터가 없을때
        if (_datas[_currentAnswer].Count == _currentStep || _datas[_currentAnswer][_currentStep].Length == 0)
        {
            _character.MoveInitPos();
            _bubble.gameObject.SetActive(false);
            _currentAnswer = -1;
            _qnaPage.gameObject.SetActive(true);
            _qnaPage.BtnClickActive(true);
            _background.MoveInitPos();
             return;
        }

        ShowBubbleText(_currentAnswer);
        
    }
}
