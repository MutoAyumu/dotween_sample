using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class WindowAnimation2 : MonoBehaviour
{
    [SerializeField] CanvasGroup _rootPanel;
    [SerializeField] VerticalLayoutGroup _layoutGroup;
    [SerializeField] float _startPosY = 0;
    [Space(10)]
    [SerializeField] float _animSpeed = 0.3f;
    [SerializeField] Ease _ease = Ease.Linear;

    bool _isPlayed;

    public void Animation()
    {
        if(_rootPanel && _layoutGroup)
        {
            var t = _rootPanel.transform;
            var startPosY = _startPosY;
            var endPosY = t.position.y;
            var param = new TweenParams();
            param.SetEase(_ease);
            var s = 300;
            var e = 0;

            if(_isPlayed)
            {
                var tmp1 = s;
                s = e;
                e = tmp1;
                var tmp2 = startPosY;
                startPosY = endPosY;
                endPosY = tmp2;
            }

            DOTween.Sequence()
                .Append(t.DOMoveY(_startPosY, 0))
                .Append(t.DOMoveY(endPosY, _animSpeed).SetAs(param))
                .Join(DOVirtual.Float(s, e, _animSpeed, t => _layoutGroup.spacing = t).SetAs(param));

            _isPlayed = !_isPlayed;
        }
    }
}
