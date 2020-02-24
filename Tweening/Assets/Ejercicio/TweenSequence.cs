using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TweenSequence : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public Transform transformInit;

    private void Start()
    {
        particleSystem.gameObject.SetActive(false);
        doTween();
    }
    private void doTween()
    {
        Sequence sqc = DOTween.Sequence();
        //Salta hacia abajo mientras cambia su tamaño y se agita la camara al caer
        sqc.Append(transform.DOMoveY(0f, 0.5f).SetEase(Ease.InOutQuad));//1
        sqc.Join(transform.DOScale(new Vector3(1.1f, 0.5f, 1.1f), 0.5f).SetEase(Ease.InOutSine));//2
        sqc.Append(transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.InOutSine));//3
        sqc.Join(Camera.main.transform.DOShakePosition(0.3f, 0.1f, 5, 5, false, true));//4
        sqc.AppendInterval(0.8f);


        //Salta hacia arriba mientras cambia su tamaño.
        sqc.Append(transform.DOMoveY(1f, 0.19f).SetEase(Ease.OutSine));//5
        sqc.Join(transform.DOScale(Vector3.one, 0.01f));//6
        sqc.AppendCallback(() =>
        {
            particleSystem.gameObject.SetActive(true);
            particleSystem.Play();
        });

        //Cambiamos el FOV
        sqc.Join(Camera.main.DOFieldOfView(45f, 0.8f));//7

        //Rota alocadamente
        sqc.Join(transform.DORotate(Vector3.up * 360, 1f).SetEase(Ease.InOutBack).SetRelative(true));//8

        //Lo hacemos desaparecer
        sqc.Join(transform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 1f));//9

        //Cambiamos el FOV de vuelta
        sqc.Append(Camera.main.DOFieldOfView(60f, 0.5f));//10

        sqc.AppendCallback(() =>
        {
            createNewCube();
        });
        sqc.Play();

    }

    private void createNewCube()
    {
        GameObject newgameObject =  Instantiate(gameObject, transformInit);
        newgameObject.name = "NewCube";
        Destroy(gameObject);
    }
}
