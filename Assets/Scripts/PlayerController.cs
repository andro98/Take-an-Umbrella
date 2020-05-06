using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float runSpeed = 10.0f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent < SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = joystick.Horizontal * runSpeed;
        if (hMove < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        rb.AddForce(new Vector2(hMove * Time.deltaTime, 0.0f));
    }
}
