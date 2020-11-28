using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    public string DamageAmount;
    public Text DamageText;
    public Rigidbody2D rb;

    public float RightDriftMax = 150f;
    public float LeftDriftMax = -150f;
    public float Speed = 30.0f;

    private void Start()
    {
        DamageText.text = DamageAmount;
        MoveDamageText();
    }

    private void MoveDamageText()
    {
        var drift = Random.Range(LeftDriftMax, RightDriftMax);
        rb.AddForce(new Vector2(drift, Speed));
    }
}