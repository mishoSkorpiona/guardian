using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sensetivity = 0.3f;
    [SerializeField]
    private float dampening;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        

    }

    private void Move()
    {
        Vector3 direction;
        

        direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        if (direction.magnitude < sensetivity)
        {
            direction = new Vector3(0, 0, 0);
            rb.velocity = rb.velocity * dampening;
        }
        else
        {
            rb.AddForce(direction * speed * Time.deltaTime);
        }
        Debug.Log($"H :{Input.GetAxis("Horizontal")} V:{Input.GetAxis("Vertical")}");
        Debug.Log(direction * speed * Time.deltaTime);
       


        
    }
}
