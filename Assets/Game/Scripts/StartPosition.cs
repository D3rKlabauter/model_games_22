using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartPosition : MonoBehaviour
{
    public GameObject prefab;
    private Camera cam = null;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.y += 5;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, worldPosition, Quaternion.identity);
            /*
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
            Debug.Log(mousePos.z);
            Debug.Log("----------");
            Debug.Log(worldPosition.x);
            Debug.Log(worldPosition.y);
            Debug.Log(worldPosition.z);
            */
        }
    }
}
