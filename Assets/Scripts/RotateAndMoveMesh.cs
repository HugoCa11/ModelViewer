using UnityEngine;

public class RotateAndMoveMesh : MonoBehaviour
{
    // Main Camera
    [SerializeField]
    private Camera cam;

    // Variable to store the position of the mouse in the previous frame
    private Vector3 prevPos = Vector3.zero;

    // Variable to stroe the difference between the previous position and
    // the position in the current frame
    private Vector3 deltaPos = Vector3.zero;

    void Update()
    {
        // If Right mouse button is pressed start rotation mode
        if(Input.GetMouseButton(1))
        {
            // Calculate the difference betwen the current and previos position of the mouse
            deltaPos = Input.mousePosition - prevPos;

            // Check if the object is upside down to determine the direction of the rotation
            if(Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                // Rotate around the Y axis (up) in world space
                transform.Rotate(transform.up, -Vector3.Dot(deltaPos, cam.transform.right), Space.World);
            }
            else
            {
                // Rotate around the Y axis (up) in world space
                transform.Rotate(transform.up, Vector3.Dot(deltaPos, cam.transform.right), Space.World);
            }

            // Rotate around the X axis in world space
            transform.Rotate(cam.transform.right, Vector3.Dot(deltaPos, cam.transform.up), Space.World);
        }

        // If middle mouse button is presed start "Move Whole model" mode
        if (Input.GetMouseButton(2))
        {
            // Calculate the difference betwen the current and previos position of the mouse
            deltaPos = Input.mousePosition - prevPos;

            // Calculate new position.
            // As the mouse only moves in x and y axis the Z position is not updated based on the mouse position
            // X and Y are divided by 100 to get a slower movement.
            Vector3 newPos = new Vector3(deltaPos.x / 100, deltaPos.y / 100, transform.position.z);

            // Enable the box collider to disable the highlight functionallity
            gameObject.GetComponent<BoxCollider>().enabled = true;

            // Update the model's position (move)
            transform.position += newPos;
        }

        // When middle mouse button is released the box collider is deactivated
        if (Input.GetMouseButtonUp(2))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        // Update prev position before next frame
        prevPos = Input.mousePosition;
    }
}
