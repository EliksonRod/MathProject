using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]float moveSpeed = 5f;
    Rigidbody2D rb;


    //WASD and Mouse tracking
    Vector2 moveDirection;
    Vector2 mousePosition;


    public void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Vector2 aimDirection = mousePosition - rb.position;
        //float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = aimAngle;
    }


    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
