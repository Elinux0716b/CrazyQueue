using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceObjects : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 60f;

    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, layer))
        {
            transform.position = hit.point;
        }
    }

    private void Start()
    {
        PositionObject();
    }
    private void Update()
    {
       
        PositionObject();

        if(Input.GetMouseButton(0))
        {
            gameObject.GetComponent<AutoCarCreate>().enabled = true;
            Destroy (gameObject.GetComponent<PlaceObjects>());
        }

        if(Input.GetKey(KeyCode.LeftShift)) {

            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
}
