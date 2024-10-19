using System;
using UnityEngine;

namespace PickUp
{
    public class GrabbableObject:MonoBehaviour
    {
        private Rigidbody objectRigibody;
        private Transform objectGrabPointTransform;

        private void Awake()
        {
            objectRigibody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (objectGrabPointTransform != null)
            {
                objectRigibody.useGravity = false;
                float lerpSpeed = 10f;
                Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
                objectRigibody.MovePosition(newPosition);
                
            }
        }

        public void Grab(Transform objectGrabePoint)
        {
            objectGrabPointTransform = objectGrabePoint;
        }

        public void Drop()
        {
            objectGrabPointTransform = null;
            objectRigibody.useGravity = true;
        }
    }
}