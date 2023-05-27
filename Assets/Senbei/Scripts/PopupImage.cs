using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace MS.Tweening
{
    public class PopupImage : MonoBehaviour
    {
        [SerializeField] float _animSpeed = 0.1f;
        [SerializeField] Ease _ease = Ease.OutBack;

        Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = this.transform;
            _thisTransform.DOScale(Vector3.zero, 0);
        }

        public Tween DOScaleX(float endValue)
        {
            return _thisTransform.DOScaleX(endValue, _animSpeed)
                        .SetEase(_ease);
        }
        public Tween DOScale(Vector3 scale)
        {
            return _thisTransform.DOScale(scale, _animSpeed)
                        .SetEase(_ease);
        }
    }
}