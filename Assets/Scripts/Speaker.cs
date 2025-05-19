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

    private string _address = "https://docs.google.com/spreadsheets/d/1UEP8KbWbf3lSReyBQqmND1xHSNpC9jEB2oMsT16EIq0";
    private string _loadRange = "B1:B1";
    private string _id = "0";

    [SerializeField] private Image _bubble;
    [SerializeField] private TMP_Text _tmp;

    [SerializeField] private GameObject _clickAnim;

    private List<List<string>> _datas = new List<List<string>>();

    private Sequence _sq;

    private void Awake()
    {
        _mainRay = GetComponent<Image>();
        _instance = this;
        _mainRay.raycastTarget = false;
    }

    private void Start()
    {
        StartCoroutine(LoadData());
    }

    private string GetCSVAddress(string m_address, string m_range, string m_id)
    {
        return $"{m_address}/export?format=csv&range={m_range}&gid={m_id}";
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

            string[] innerData = texts[i].Split('/');

            for (int j = 0; j < innerData.Length; j++)
            {
                tempList.Add(innerData[j]);
            }
        }
    }

    public void ShowBubbleText(int m_idx)
    {
        _sq?.Kill();

        _bubble.gameObject.SetActive(true);
        _tmp.text = "";
        _mainRay.raycastTarget = true;

        _sq = DOTween.Sequence();

        _sq.Append(_tmp.DOText(_datas[m_idx][0], 3f).SetEase(Ease.Linear));
        _sq.OnComplete(() => 
        { 
            _clickAnim.SetActive(true);


        });
    }
}
