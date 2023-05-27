using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MS.Tweening;

public class SenbeiTest : MonoBehaviour
{
    [SerializeField] string[] _genruArray;
    [SerializeField] GenreListAnimation _genruAnim;
    [Space(10)]
    [SerializeField] string[] _commentArray;
    [SerializeField] CommentAnimation _commentAnim;

    public void Test1()
    {
        _genruAnim.StartAnimation(_genruArray);
    }
    public void Test2()
    {
        _commentAnim.StartAnimation(_commentArray);
    }
}
