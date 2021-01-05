using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //public float sensitivity;
    //public Transform playerTransform;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    Rotate();
    //}

    //public void Rotate()
    //{
    //    float xPos = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
    //    //float yPos = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

    //    //playerTransform.rotation = Quaternion.Euler(new Vector3(0f, xPos, 0f));
    //    playerTransform.Rotate(Vector3.up * xPos);
    //}

    public Camera cam;
    public float maximumLength;

    private Ray rayMouse;
    private Vector3 mousePos;
    private Vector3 direction;
    private Quaternion rotation;

    private void Update()
    {
        if (cam != null)
        {
            RaycastHit hit;
            mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin,rayMouse.direction,out hit,maximumLength))
            {
                RotateToMouseDir(gameObject,hit.point);
            }
            else
            {
                Debug.LogError("No Cam");
            }
        }
    }

    public void RotateToMouseDir(GameObject obj, Vector3 destianation)
    {
        destianation = destianation - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation,rotation, 1);
    }


}
