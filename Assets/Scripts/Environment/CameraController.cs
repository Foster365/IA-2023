using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public CameraMode cameraSecurity;

    bool inSight;

    // Start is called before the first frame update
    void Awake()
    {
        cameraSecurity = GetComponent<CameraMode>();   
    }

    private void Start()
    {
        inSight = false;
    }

    // Update is called once per frame
    void Update()
    {

        FieldOfView();

    }

    public void FieldOfView()
    {

        if(cameraSecurity.FieldofView(target))
        {
            Debug.Log("In sight");
            inSight = true;
        }
        else
        {
            Debug.Log("Out of sight");
            inSight = false;
        }
    }
}
