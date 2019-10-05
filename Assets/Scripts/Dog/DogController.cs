using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogController : MonoBehaviour
{
    [SerializeField] float movement_speed = 3;
    [SerializeField] float jump_force = 300;
    [SerializeField] float jump_timer = 1.2f;
    [SerializeField] float can_jump = 0f;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform mouth;

    private void Start()
    {
        // anim = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveDog();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Bark();
        }
    }

    private void Bark()
    {
        print("BORK BORK");
        EventManager.TriggerEvent("BARK");
    }

    private void MoveDog()
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
            // rb.AddForce(0, jump_force, 0);
            can_jump = Time.time + jump_timer;
            // anim.SetTrigger("jump");
        }
    }
}
