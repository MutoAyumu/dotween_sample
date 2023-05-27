using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MS.Tweening;
using DG.Tweening;
using UnityEngine.UI;

namespace MS.Tweening
{
    public class CommentAnimation : MonoBehaviour
    {
        [SerializeField] PopupImage[] _commentObjectArray;
        [SerializeField] float _appendDelayTime = 0f;

        public void StartAnimation(string[] array)
        {
            var seq = DOTween.Sequence();
            var scale = Vector3.one;

            for (int i = 0; i < array.Length; i++)
            {
                var obj = _commentObjectArray[i];
                var child = obj.transform.GetChild(0);

                if (child.TryGetComponent(out Text text))
                {
                    text.text = array[i];
                }
                else
                {
                    Debug.LogError($"{obj.name}にTextがアタッチされていませんでした");
                }


                seq.Append(obj.DOScale(scale));
                seq.AppendInterval(_appendDelayTime);
            }

            seq.Play();
        }
    }
}