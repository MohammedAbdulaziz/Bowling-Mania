using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed;
    Vector3 mover;
    public float Strength = 3f;
    private Rigidbody rb;
    private bool launched;
    public GameObject other;
    public Rigidbody otherRb;
    public static bool exit;
    public CameraController cameraController;
    void Start()
    {
        exit = false;
        rb = GetComponent<Rigidbody>();
        launched = false;
    }

    void Update()
    {
        if (!launched)
        {
            mover = transform.position;
            mover.x = (Mathf.Sin(7 * Time.time) * Strength);
            transform.position = mover;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                launched = true;
                rb.velocity = transform.forward * Speed;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            exit = true;
            (cameraController as Behaviour).enabled = false;
            StartCoroutine(Delay(4));   
        }

    }
    public IEnumerator Delay (float delay)
    {
        yield return new WaitForSeconds(delay);
        other.gameObject.SetActive(false);
    }
}
