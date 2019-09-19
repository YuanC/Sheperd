using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float movement_speed = 3;
    public float jump_force = 300;
    public float jump_timer = 1.2f;
    [SerializeField]
    private float can_jump = 0f;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveDog();
    }

    void MoveDog()
    {
        float move_horizontal = Input.GetAxisRaw("Horizontal");
        float move_vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0.0f, move_vertical);

        if (movement != Vector3.zero)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            // anim.SetInteger("Walk", 1);
        }
        else
        {
            // anim.SetInteger("Walk", 0);
        }

        this.transform.Translate(movement * movement_speed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && Time.time > can_jump)
        {
            rb.AddForce(0, jump_force, 0);
            can_jump = Time.time + jump_timer;
            // anim.SetTrigger("jump");
        }
    }
}
