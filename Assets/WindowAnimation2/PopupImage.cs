using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopupImage : MonoBehaviour
{
    [SerializeField] float _animSpeed = 0.1f;
    [SerializeField] Ease _ease = Ease.OutBack;

    Transform _thisTransform;

    private void Start()
    {
        _thisTransform = this.transform;
        _thisTransform.DOScaleX(0, 0);
    }

    public Tween DOScaleX(float endValue)
    {
        return _thisTransform.DOScaleX(endValue, _animSpeed)
                    .SetEase(_ease);
    }
}
