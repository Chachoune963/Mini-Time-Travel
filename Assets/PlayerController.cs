using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private bool jumpInput;

    public float speed = 0;
    public float jumpForce;

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Jump")) jumpInput = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveInput * (speed * Time.fixedDeltaTime));
        if (jumpInput)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpInput = false;
        }
    }
}
