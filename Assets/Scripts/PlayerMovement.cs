using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerBody;

    public float speed;

	void Start ()
    {
        playerBody = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 movement = new Vector3(ray.direction.x * 10, 0.0f, ray.direction.z * 10);
			
			float movementLength = Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.z, 2));
			movement = speed * (movement/movementLength);

            playerBody.AddForce(movement * speed);
        }
    }
}
