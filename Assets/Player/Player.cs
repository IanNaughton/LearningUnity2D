using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    public float runSpeed = 40f;
    public float horizontalMovement = 0f;
    public bool jump = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        //if (Input.GetButtonDown("Jump"))
        //{
        //    jump = true;
        //}
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * runSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}