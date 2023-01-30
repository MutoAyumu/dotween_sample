using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WindowAnimation3 : MonoBehaviour
{
    [SerializeField] PopupImage _rootPanel;
    [SerializeField] GridLayoutGroup _grid;
    [SerializeField] PopupImage _backButton;
    [SerializeField] PopupImage _itemPrefab;
    [SerializeField] float _itemAnimationDelay = 0.15f;
    [SerializeField] int _count = 5;

    public void OpenAnimation()
    {
        if (_rootPanel && _itemPrefab && _grid && _backButton)
        {
            var scale = Vector3.one;

            var seq = DOTween.Sequence()
                        .Append(_rootPanel.DOScale(scale))
                        .AppendInterval(_itemAnimationDelay);

            foreach (Transform go in _grid.GetComponentInChildren<Transform>())
            {
                Destroy(go.gameObject);
            }

            for (int i = 0; i < _count; i++)
            {
                var item = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity, _grid.transform);
                item.name = $"Item[{i}]";

                seq.Append(item.DOScale(scale));
            }

            seq.AppendInterval(_itemAnimationDelay);
            seq.Append(_backButton.DOScale(scale));
            seq.Play();
        }
    }
    public void CloseAnimation()
    {
        if(_rootPanel && _backButton)
        {
            _rootPanel.DOScale(Vector3.zero).OnComplete(() => _backButton.DOScale(Vector3.zero));
        }
    }
}
