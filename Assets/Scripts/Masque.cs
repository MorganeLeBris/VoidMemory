using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Masque : MonoBehaviour
{

    /// <summary>
    /// 1 - The speed of the ship
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    // 2 - Store the movement and the component
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    void Update()
    {
        // 3 - Retrieve axis information
        float inputX = Input.GetAxis("HorizontalMask");
        float inputY = Input.GetAxis("VerticalMask");

        // 4 - Movement per direction
        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

       

        // 6 - Make sure we are not outside the camera bounds
        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0.07f, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0.86f, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0.27f, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0.78f, dist)
        ).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
        );
    }

    void FixedUpdate()
    {
        // 5 - Get the component and store the reference
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // 6 - Move the game object
        rigidbodyComponent.velocity = movement;
    }


}

