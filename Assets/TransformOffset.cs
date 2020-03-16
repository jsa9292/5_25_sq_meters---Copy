using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOffset : MonoBehaviour
{
    public Vector3 rot_offset;
    public Vector3 pos_offset;

    private Vector3 rot_init;
    private Vector3 pos_init;
    // Start is called before the first frame update
    private void Awake()
    {
        pos_offset = transform.parent.position;
    }
    void Start()
    {
        //rot_offset += transform.eulerAngles;

        transform.parent.rotation = Quaternion.Inverse(transform.rotation);
        transform.parent.position -= transform.position - pos_offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.parent.position += Vector3.up * 0.01f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.parent.position -= Vector3.up * 0.01f;
        }
    }
    private void LateUpdate()
    {
        //rot_init = transform.eulerAngles;
        //transform.eulerAngles = rot_init - rot_offset;

        //pos_init = transform.position;
        //transform.position = pos_init - pos_offset;
    }
}
