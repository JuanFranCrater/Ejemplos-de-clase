using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    IControlable controlable;

    public GameObject controlableTarget;
    private void Start()
    {
        controlable = controlableTarget.GetComponent<IControlable>();
    }

    private void Update()
    {
        CheckBinding(() => Input.GetKey(KeyCode.UpArrow), () => controlable.Up());
        CheckBinding(() => Input.GetKey(KeyCode.DownArrow), () => controlable.Down());
        CheckBinding(() => Input.GetKey(KeyCode.LeftArrow), () => controlable.Left());
        CheckBinding(() => Input.GetKey(KeyCode.RightArrow), () => controlable.Right());

        CheckBinding(() => Input.GetKeyDown(KeyCode.Space), () => controlable.Jump());
        CheckBinding(() => Input.GetKey(KeyCode.LeftControl), () => controlable.Action());
    }
    void CheckBinding(Func<bool> condition, Action action)
    {
        if (condition())
            action();
    }
}
