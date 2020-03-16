using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class timer : MonoBehaviour
{

    public float timeScale;
    public GameObject[] objList;
    public float[] timeList;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Time.timeScale = timeScale;
        for (int i = 0;i < objList.Length; i++) {
            if (timeList[i] <= Time.timeSinceLevelLoad)
            {
                objList[i].SetActive(true);
            }
        }
    }

}
