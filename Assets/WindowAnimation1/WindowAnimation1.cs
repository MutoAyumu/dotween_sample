using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WindowAnimation1 : MonoBehaviour
{
    [SerializeField] CanvasGroup _rootPanel;
    [Space(10)]
    [SerializeField] float _animSpeed = 0.35f;
    [SerializeField] Ease _ease = Ease.InOutBack;

    bool _isPlayed;

    public void Animation()
    {
        if(_rootPanel)
        {
            var size = Vector3.one;
            var alpha = 1;
            var t = _rootPanel.transform;

            if (_isPlayed)
            {
                size = Vector3.zero;
                alpha = 0;
            }

            var param = new TweenParams();
            param.SetEase(_ease);

            DOTween.Sequence()
                .Append(t.DOScale(size, _animSpeed).SetAs(param))
                .Join(_rootPanel.DOFade(alpha, _animSpeed).SetAs(param));

            _isPlayed = !_isPlayed;
        }
    }
}
