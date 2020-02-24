using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardController : MonoBehaviour
{
    IControlable controlable;

    public GameObject controlableTarget;
    private void Start()
    {
        controlable = controlableTarget.GetComponent<IControlable>();
    }

    private void Update()
    {
        CheckBinding(() => Input.GetKey(KeyCode.LeftArrow), () => controlable.Left());
        CheckBinding(() => Input.GetKey(KeyCode.RightArrow), () => controlable.Right());

        CheckBinding(() => Input.GetKeyDown(KeyCode.Space), () => controlable.Jump());
    }
    void CheckBinding(Func<bool> condition, Action action)
    {
        if (condition())
            action();
    }
}
