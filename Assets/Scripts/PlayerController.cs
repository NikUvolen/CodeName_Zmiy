using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public float speed;
    private float normalspeed;
    private Vector3 change;
    private float coldoun = 0;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        normalspeed = speed;
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (change != Vector3.zero)
        {
            Jerk();
            MoveCharacter();
        }
        if (change.x == 0 && change.y == 0)
        {
            anim.SetInteger("pipirka", 1);
        }
        else
        {
            Flip();
            anim.SetInteger("pipirka", 2);
        }

    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void Jerk()
    {
        if (Input.GetKey(KeyCode.Space) & Time.time - coldoun > 5)
        {
            Debug.Log("Рывок!!");
            speed *= 40;
            coldoun = Time.time;
        }
        else
        {
            Debug.Log(Time.time - coldoun);
            speed = normalspeed;
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
