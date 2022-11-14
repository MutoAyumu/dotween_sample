using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class Sample1 : MonoBehaviour
{
    [SerializeField]
    Ease _fadeEase = Ease.InSine;
    [SerializeField]
    Ease _scaleEase = Ease.InSine;

    [SerializeField]
    float _animTime = 0.8f;

    [SerializeField]
    bool _playOnAwake;

    CanvasGroup _canvasGroup;
    Sequence _sequence;
    Transform _thisTransform;

    private void Awake()
    {
        _thisTransform = this.transform;
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        if(_playOnAwake)
            SampleAnimation();    
    }

    public void SampleAnimation()
    {
        _canvasGroup.alpha = 0;
        _thisTransform.localScale = Vector3.zero;

        _sequence.Append(_canvasGroup.DOFade(1f, _animTime).SetEase(_fadeEase))
                 .Join(_thisTransform.DOScale(Vector3.one, _animTime).SetEase(_scaleEase));
    }
}
