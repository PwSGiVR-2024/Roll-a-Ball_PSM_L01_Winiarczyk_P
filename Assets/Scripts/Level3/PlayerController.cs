using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 15;
    private Vector3 moveDir;

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * movespeed * Time.deltaTime);
    }
}
