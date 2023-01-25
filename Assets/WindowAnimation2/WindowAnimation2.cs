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
            var v = 0;

            if(_isPlayed)
            {
                v = 300;
                pos = _pos[1].position;
            }

            DOTween.Sequence()
                .Append(t.DOMove(pos, _animSpeed)
                    .SetEase(_ease))
                .Join(DOVirtual.Float(_layoutGroup.spacing, v, _animSpeed, value => _layoutGroup.spacing = value)
                    .SetEase(_ease)
                    .SetDelay(_animSpeed / 3));

            _isPlayed = !_isPlayed;
        }
    }
}
