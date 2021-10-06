using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3;
    public float speedRotate = 20;
    public float lockAngleRotateX = 45;

    public Transform cameraTransform;
    public Rigidbody selfRb;

    public float newAngle;
    public float newRotate;

    private void Start()
    {
        cameraTransform.localRotation = Quaternion.identity;
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.TransformDirection(new Vector3(hAxis, 0, vAxis));
        //selfRb.MovePosition(transform.position + moveDirection * speed / 50);

        selfRb.velocity = moveDirection * speed;
    }

    void Update()
    {
        Rotate();

        Vector3 nowScale = new Vector3(1, 1, 1);
        if (Input.GetKey(KeyCode.LeftControl)) transform.localScale = new Vector3(1, 0.5f, 1);
        transform.localScale = nowScale;

        speed = 3;
        if (Input.GetKey(KeyCode.LeftShift)) speed = 9;
    }

    private void Rotate()
    {
        float yRotate = Input.GetAxis("Mouse X");
        transform.Rotate(0, yRotate * speedRotate * Time.deltaTime, 0);

        float xRotate = -Input.GetAxis("Mouse Y");

        float newRotate = this.newRotate = xRotate * speedRotate * Time.deltaTime;
        float newAngle = this.newAngle = Vector3.SignedAngle(transform.forward, cameraTransform.forward, transform.right) + newRotate;
        if (Mathf.Abs(newAngle) > lockAngleRotateX) return;
        cameraTransform.Rotate(newRotate, 0, 0);
    }
}
