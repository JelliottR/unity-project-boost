using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody m_rigidBody;

    // Use this for initialization
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidBody.AddRelativeForce(new Vector3(0, 1.5f, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
        }
        else if (Input.GetKey(KeyCode.D))
        {
        }
    }
}