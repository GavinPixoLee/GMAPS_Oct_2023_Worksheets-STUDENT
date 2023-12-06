using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir, gravityNorm;
    private HVector2D moveDir;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        gravityDir = new HVector2D(planet.position - transform.position);  
        moveDir = new HVector2D(gravityDir.y, -gravityDir.x);
        moveDir.Normalize();
        moveDir *= -1f;

        rb.AddForce((moveDir * force).ToUnityVector3());

        gravityNorm = new HVector2D(gravityDir.x, gravityDir.y);
        gravityNorm.Normalize();

        rb.AddForce((gravityNorm * gravityStrength).ToUnityVector3());

        rb.MoveRotation(Quaternion.Euler(0f, 0f, gravityDir.FindAngle(new HVector2D(0, -1)) * Mathf.Rad2Deg));

        Debug.Log(gravityDir.FindAngle(new HVector2D(0, -1)) * Mathf.Rad2Deg);

        DebugExtension.DebugArrow(transform.position, (gravityNorm * gravityStrength).ToUnityVector3(), Color.red);

        DebugExtension.DebugArrow(transform.position, (moveDir * force).ToUnityVector3(), Color.blue);

        // Your code here
        // ...
    }
}
