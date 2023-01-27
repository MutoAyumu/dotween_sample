using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WindowAnimation2 : MonoBehaviour
{
    [SerializeField] CanvasGroup _rootPanel;
    [SerializeField] VerticalLayoutGroup _layoutGroup;
    [SerializeField] Transform[] _pos = new Transform[2];
    [Space(10)]
    [SerializeField] float _animSpeed = 0.3f;
    [SerializeField] Ease _ease = Ease.Linear;

    bool _isPlayed;

    public void Animation()
    {
        if(_rootPanel && _layoutGroup)
        {
            var t = _rootPanel.transform;
            var pos = _pos[0].position;
            var space = 0;
            var endValue = 1;
            var alpha = 1;
            var param = new TweenParams();
            param.SetEase(_ease);

            if(_isPlayed)
            {
                space = 300;
                alpha = 0;
                endValue = 0;
                pos = _pos[1].position;
            }

            DOTween.Sequence()
                .Append(t.DOMove(pos, _animSpeed)
                    .SetAs(param))
                .Join(_rootPanel.DOFade(alpha, _animSpeed)
                    .SetAs(param))
                .Join(DOVirtual.Float(_layoutGroup.spacing, space, _animSpeed, value => _layoutGroup.spacing = value)
                    .SetEase(_ease)
                    .SetDelay(_animSpeed / 3))
                .Join(GetLayoutChildren(endValue));

            _isPlayed = !_isPlayed;
        }
    }
    Tween GetLayoutChildren(float endValue)
    {
        var seq = DOTween.Sequence();
        
        foreach(Transform go in _layoutGroup.GetComponentInChildren<Transform>())
        {
            var co = go.GetComponent<PopupImage>();
            seq.Append(co.DOScaleX(endValue));
        }

        return seq;
    }
}
