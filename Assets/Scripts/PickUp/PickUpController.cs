using System.Collections;
using System.Collections.Generic;
using PickUp;
using UnityEngine;
using UnityEngine.UI;

public class PickUpController : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabePoint;
    [SerializeField] private LayerMask pickUpLayerMask;
    private readonly float pickUpDistance = 30f;
    private GrabbableObject grabbableObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit, pickUpDistance, pickUpLayerMask))
            {
                if (grabbableObject == null)
                {
                    if (hit.transform.TryGetComponent(out grabbableObject))
                    {
                        grabbableObject.Grab(objectGrabePoint);
                        Debug.Log(hit.collider.transform);
                    }
                }
                else
                {
                    grabbableObject.Drop();
                    grabbableObject = null;
                }
            }
            
        }
    }
}
