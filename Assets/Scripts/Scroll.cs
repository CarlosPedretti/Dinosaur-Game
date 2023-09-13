using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.left * GameManager.Instance.GetScrollSpeed() * Time.deltaTime);
    }
}