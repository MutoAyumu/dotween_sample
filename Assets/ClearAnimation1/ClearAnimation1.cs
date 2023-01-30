using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClearAnimation1 : MonoBehaviour
{
    [SerializeField] CanvasGroup _root;
    [SerializeField] Image[] _stars;
    [SerializeField] InputField _count;
    [Space(10)]
    [SerializeField] float _animSpeed = 0.3f;
    [SerializeField] float _interval = 0.2f;
    [SerializeField] Ease _ease = Ease.Linear;

    Vector3 _startScale;
    Vector3[] _starsScale;

    private void Awake()
    {
        _startScale = _root.transform.localScale;
        _starsScale = new Vector3[3];

        for (int i = 0; i < _stars.Length; i++)
        {
            _starsScale[i] = _stars[i].transform.localScale;
        }
    }

    public void OpenAnimation()
    {
        var seq = DOTween.Sequence();
        var param = new TweenParams();
        param.SetEase(_ease);
        var c = int.Parse(_count.text);
        c = Mathf.Min(3, c);
        _count.text = $"{c}";

        seq
            .Append(_root.DOFade(1, _animSpeed).SetAs(param))
            .Join(_root.transform.DOScale(Vector3.one, _animSpeed).SetAs(param))
            .AppendInterval(_interval);

        for (int i = 0; i < c; i++)
        {
            seq
                .Append(_stars[i].transform.DOScale(Vector3.one, _animSpeed).SetAs(param))
                .Join(_stars[i].DOFade(1, _animSpeed).SetAs(param));
        }

        seq.Play();
    }
    public void CloseAnimation()
    {
        var seq = DOTween.Sequence();
        var param = new TweenParams();
        param.SetEase(_ease);

        seq
            .Append(_root.transform.DOScale(_startScale, _animSpeed).SetAs(param))
            .Join(_root.DOFade(0, _animSpeed).SetAs(param))
            .OnComplete(() =>
            {
                for(int i = 0; i < _stars.Length; i++)
                {
                    _stars[i].DOFade(0, 0);
                    _stars[i].transform.localScale = _starsScale[i];
                }
            });
    }
}
