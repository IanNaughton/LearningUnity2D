using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public float DamageAmount;
    public Text DamageText;
    public Rigidbody2D rb;

    public float RightDriftMax = 150f;
    public float LeftDriftMax = -150f;
    public float Speed = 30.0f;

    void Start()
    {
        DamageText.text = DamageAmount.ToString();
        MoveDamageText();
    }
    void MoveDamageText()
    {
        var drift = Random.Range(LeftDriftMax, RightDriftMax);
        rb.AddForce(new Vector2(drift, Speed));
    }
}
