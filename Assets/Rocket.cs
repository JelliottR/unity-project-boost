using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody m_rigidBody;
    private AudioSource m_audioSource;

    [SerializeField] float m_rcsThrust = 100f;
    [SerializeField] float m_mainThrust = 800f;

    // Use this for initialization
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("Friendly.");
                break;
            default:
                print("You died.");
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float thrustThisFrame = m_mainThrust * Time.deltaTime;
            m_rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

            if (!m_audioSource.isPlaying)
            {
                m_audioSource.Play();
            }
        }
        else
        {
            m_audioSource.Stop();
        }
    }

    private void Rotate()
    {

        m_rigidBody.freezeRotation = true; // Take manual control of the rotation.
        float rotationThisFrame = m_rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        m_rigidBody.freezeRotation = false; // Resume physics control of rotation.
    }
}