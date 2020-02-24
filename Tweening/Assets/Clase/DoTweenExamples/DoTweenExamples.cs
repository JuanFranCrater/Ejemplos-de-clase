using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenExamples : MonoBehaviour
{
    public Vector3 EndRotation;
    public Vector3 EndPosition;
    public float Duration;
    public AnimationCurve animationCurve;
    public Ease MyEase;

    private void Start()
    {
        //TweenPosition();
        //TweenRotation();
        // TweenPositionGeneric();
        //TweenPositionLoop();
        TweenCurve();
    }

    public void TweenPosition()
    {
        transform.DOMove(EndPosition,Duration)
            .SetEase(MyEase)
            .Play();
    }

    public void TweenRotation()
    {
        transform.DORotate(EndRotation, Duration)
            .SetEase(MyEase)
            .Play();
    }

    public void TweenPositionGeneric()
    {
        DOTween.To(() => transform.position, x => transform.position = x, EndPosition, Duration)
            .SetEase(MyEase)
            .Play();
    }


    public void TweenPositionLoop()
    {
        transform.DOMove(EndPosition, Duration)
             .SetEase(MyEase)
             .OnComplete(() => HazAlgo())
             .SetLoops(2, LoopType.Incremental)
             .Play();
    }

    public void TweenCurve()
    {
        transform.DOMove(EndPosition, Duration).
          SetEase(animationCurve).
          Play();
    }

    public void HazAlgo()
    {
        Debug.Log("Hola soy yo, el chocu");
    }
}
