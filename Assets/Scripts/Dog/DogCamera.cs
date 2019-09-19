using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCamera : MonoBehaviour
{
    public Transform dog_transform;
    [Range(0.01f, 1.0f)]
    public float smoothing = 0.5f;

    private Vector3 camera_offset;

    private void Start()
    {
        camera_offset = this.transform.position - dog_transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 new_position = dog_transform.position + camera_offset;
        this.transform.position = Vector3.Slerp(this.transform.position, new_position, smoothing);
        this.transform.LookAt(dog_transform);
    }
}
