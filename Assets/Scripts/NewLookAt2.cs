using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLookAt2 : MonoBehaviour
{
    [SerializeField] Vector3 velocity;
    Vector3 acceleration;
    [SerializeField] Vector3 maxVelocity;



    //[SerializeField] private float speed = 1;

    private void Awake()
    {
        
    }

    void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();
        acceleration = mousePosition - transform.position;
        
        float angle = Mathf.Atan2(acceleration.y, acceleration.x) - Mathf.PI / 2;
        RotateZ(angle);

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (Vector3.Distance(velocity, acceleration) >= 5.0f) 
        {
            Debug.Log("a");
        }
           
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundaries"))
        {
            acceleration = Vector3.zero;
            velocity = Vector3.zero;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
    }

    public Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
        Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
