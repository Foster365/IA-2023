using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform playerTransform;

    private void LateUpdate() //Se actualiza después de que se mueve el player
    {

        Vector3 newPosition = playerTransform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90, playerTransform.eulerAngles.y, 0);
        
    }
}
