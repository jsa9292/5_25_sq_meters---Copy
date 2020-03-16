using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinder : MonoBehaviour
{
    public Rigidbody head;
    public Camera cam;
    LayerMask mask;
    private int inv;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("UI");
        inv = ~(mask);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        cam.cullingMask = mask >> 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        cam.cullingMask = inv >> 0;
    }
}
