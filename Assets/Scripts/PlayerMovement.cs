using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Renderer playerRenderer;
    private Rigidbody playerBody;

    public float acceleration;

	void Start ()
    {
        playerRenderer = GetComponent<Renderer>();
        playerBody = GetComponent<Rigidbody>();
	}

    void Update()
    {
        float speed = playerBody.GetPointVelocity(playerBody.transform.position).magnitude;

        playerRenderer.material.color = new Color(1, Mathf.Clamp(1 - (speed / 15), 0f, 1f), 0, 1);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 movement = new Vector3(ray.direction.x * 10, 0.0f, ray.direction.z * 10);

            playerBody.AddForce((movement / movement.magnitude) * acceleration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            acceleration = acceleration * 3;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            acceleration = acceleration / 3;
        }
    }
}
