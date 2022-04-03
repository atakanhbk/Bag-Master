using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swerve : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 FirstPos;
    private Vector3 LastPos;
    public float swerveSensitivity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SwerveNew();
    }


    void SwerveNew()
    {

        if (Input.GetMouseButtonDown(0))
        {
            FirstPos = Input.mousePosition;


        }
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = transform.position;
            //pos.x = LastPos.x + (FirstPos - Input.mousePosition).x / -swerveSensitivity;
            pos = new Vector3(LastPos.x + (FirstPos - Input.mousePosition).x / -swerveSensitivity, pos.y, transform.position.z);
            pos.x = Mathf.Clamp(pos.x, -4f, 4f);

            transform.position = pos;
            //transform.position = new Vector3(LastPos.x + (FirstPos - Input.mousePosition).x / -swerveSensitivity, 0, transform.position.z);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.4f, 1f), 0, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            LastPos = transform.position;
        }
    }
}