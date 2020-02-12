using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SequencesExamples : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestCube();
    }

    public void TestCube()
    {
        Sequence cubeSeq = DOTween.Sequence();
        cubeSeq.Append(transform.DOMoveY(2, 3).SetEase(Ease.InOutQuad));
        cubeSeq.PrependInterval(1);
        cubeSeq.AppendInterval(1);
        cubeSeq.Append(transform.DOMoveX(2, 3).SetEase(Ease.InOutQuad));
        cubeSeq.Join(transform.DOScale(new Vector3(2, 2, 2), 5).SetEase(Ease.InOutQuad));//Will do at the same time the last one called
        cubeSeq.Insert(1, transform.DORotate(new Vector3(100, 00, 0), 5).SetEase(Ease.InOutQuad));
        cubeSeq.AppendCallback(() =>
        {

        }
        );
        cubeSeq.Play();

        }
}
