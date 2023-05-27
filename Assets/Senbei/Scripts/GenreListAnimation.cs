using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace MS.Tweening
{
    public class GenreListAnimation : MonoBehaviour
    {
        [SerializeField] VerticalLayoutGroup _verticalLayout;
        [SerializeField] PopupImage _genruObjectPrefab;

        public void StartAnimation(string[] array)
        {
            if(!_verticalLayout || !_genruObjectPrefab)
            {
                Debug.LogError($"VerticalLayoutGroupまたはPrefabが設定されていませんでした");
                return;
            }

            var seq = DOTween.Sequence();
            var scale = Vector3.one;

            for (int i = 0; i < array.Length; i++)
            {
                var obj = CreatePrefab(array[i]);
                
                seq.Append(obj.DOScale(scale));
            }

            seq.Play();
        }

        PopupImage CreatePrefab(string str)
        {
            var obj = Instantiate(_genruObjectPrefab, _verticalLayout.transform);
            var child = obj.transform.GetChild(0);

            if (child.TryGetComponent(out Text text))
            {
                text.text = str;
            }
            else
            {
                Debug.LogError($"{obj.name}にTextがアタッチされていませんでした");
            }

            return obj;
        }
    }
}