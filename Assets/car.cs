using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EnumColor
{
    White,
    Blue,
    Yellow,
    Red,
    Green
}

public class car : MonoBehaviour
{
    public bool isGoing;

    public Rigidbody2D rigidbody2D;
    public EnumColor color;

    [Button]
    public void Rotate()
    {
       transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.forward * 90);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.zero;
        TheGameUI.Instance.Check();
    }

    private Vector3 pos;

    [Button]
    public void Go()
    {
        pos = transform.position;
        //todo: uncomment
        isGoing = true;
        rigidbody2D.velocity = -transform.right * 7;
    }

    public void Stop()
    {
        isGoing = false;
        rigidbody2D.velocity = Vector2.zero;
        transform.position = pos;
        TheGameUI.Instance.Check();
    }
}