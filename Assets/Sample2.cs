using UnityEngine;
using DG.Tweening;

public class Sample2 : MonoBehaviour
{
    [SerializeField]
    RectTransform _rect1;
    [SerializeField]
    float _duration1 = 0.3f;

    [Space(10)]

    [SerializeField]
    RectTransform _rect2;
    [SerializeField]
    float _duration2 = 0.3f;

    [Space(10)]

    [SerializeField]
    RectTransform _rect3;
    [SerializeField]
    float _duration3 = 0.2f;

    [SerializeField]
    bool _playOnAwake;

    private void Awake()
    {
        _rect1.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (_playOnAwake)
            SampleAnimation();
    }

    public void SampleAnimation()
    {
        DOTween.Sequence()
            //テキストを弾ませる
            .Append(_rect1.DOScaleX(0.5f, _duration1).SetEase(Ease.OutBack))
            .Join(_rect1.DOScaleY(2f, _duration1).SetEase(Ease.OutBack))
            //白いイメージを表示
            .AppendCallback(() => _rect2.gameObject.SetActive(true))
            //フェードさせる
            .Append(_rect1.DOScaleX(2f, _duration1).SetEase(Ease.OutQuart))
            .Join(_rect1.DOScaleY(0f, _duration1).SetEase(Ease.OutQuart))
            .Join(_rect2.DOScaleY(0f, _duration2).SetEase(Ease.OutQuart))
            .Join(_rect2.DOScaleX(2f, _duration2).SetEase(Ease.OutQuart))
            //黒いイメージを表示
            .Join(_rect3.DOScaleY(0.75f, _duration3).SetEase(Ease.InOutBack))
            .Join(_rect3.DOScaleX(1.25f, _duration3).SetEase(Ease.InOutBack))
            .Append(_rect3.DOScale(Vector3.one, _duration3).SetEase(Ease.OutQuart))
            //初期化
            .OnStart(() =>
            {
                _rect1.localScale = Vector3.one;
                _rect1.gameObject.SetActive(true);
                _rect2.gameObject.SetActive(false);
                _rect2.localScale = Vector3.one;
                _rect3.localScale = Vector3.zero;
            });
    }
}