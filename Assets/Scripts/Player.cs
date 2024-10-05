using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera camMain;

    [SerializeField] private float mouseMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camMain = Camera.main;
    }

    private void checkMouseLock()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            switch (Cursor.lockState)
            {
                case CursorLockMode.Locked: Cursor.lockState = CursorLockMode.None; break;
                case CursorLockMode.None: Cursor.lockState = CursorLockMode.Locked; break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
        rotation();

        checkMouseLock();
    }

    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * mouseMoveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back) * mouseMoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left) * mouseMoveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right) * mouseMoveSpeed * Time.deltaTime;
        }
    }

    private void rotation()
    {
        transform.rotation = Quaternion.Euler(0f, camMain.transform.eulerAngles.y, 0f);
    }
}
