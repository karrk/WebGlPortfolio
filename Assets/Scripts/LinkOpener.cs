using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkOpener : MonoBehaviour
{
    [SerializeField] private string _url;

    private Button _btn;

    private void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OpenURL);
    }

    private void OpenURL()
    {
        Application.OpenURL(_url);
    }
}
