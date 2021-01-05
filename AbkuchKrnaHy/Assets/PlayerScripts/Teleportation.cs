using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject prefab;
    //public float distance;
    public Transform playerPos;

    GameObject teleport;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Teleport();
        Dash();
    }
    void Update()
    {

    }
    private void OnMouseDown()
    {
        Vector3 newPos = playerPos.position + new Vector3(0f, 0f, 2f);
        GameObject telePref = Instantiate(prefab, newPos, Quaternion.identity) as GameObject;

        teleport = telePref;
    }
    public void Teleport()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (teleport != null)
            {
                playerPos.transform.position = teleport.transform.position;
            }

        }
    }

    public void Dash()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 newPos = new Vector3(0f, 0f, (playerPos.position.z + 2f));
            playerPos.transform.position = newPos;

        }
    }

}
