using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_3DPlayer : MonoBehaviour
{
    public Camera pCamera;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    public Image pointer;

    void Start()
    {
        Vector3 rot = pCamera.transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        pCamera.transform.rotation = localRotation;
        pointer.transform.localPosition = new Vector3(Input.mousePosition.normalized.x, Input.mousePosition.normalized.y, pCamera.transform.localPosition.z + 1);
        if (Input.GetKeyDown(KeyCode.E)) Cursor.lockState = CursorLockMode.None;
        if (Input.GetMouseButtonDown(0)) onClick();
    }

    private void onClick()
    {
        Debug.Log("Clicked");
        RaycastHit hit;
        Ray ray = pCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHit = hit.collider.gameObject;
            Debug.Log("Hitted object named " + objectHit.name);
            //Do something with gameobject
            if(objectHit.tag != "Scene")
            {
                if(objectHit.tag == "Proyect")objectHit.GetComponent<Button>().onClick.Invoke();
                else if (objectHit.tag == "Types") objectHit.GetComponent<Button>().onClick.Invoke();
                else if (objectHit.GetComponent<C_3DRelatedButton>().canBeInteracted)
                {
                    Debug.Log("Can be interacted with");
                    objectHit.GetComponent<C_3DRelatedButton>().Selected();
                }
            }
        }
    }
}
