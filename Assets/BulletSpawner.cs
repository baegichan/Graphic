using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject bullet;
    

    // Update is called once per frame
    void Update()
    {
    if(Input.GetMouseButtonDown(0)==true)
    {
            var screenPoint = Input.mousePosition;
            screenPoint.z = 1.0f;
            Instantiate(bullet, Camera.main.ScreenToWorldPoint(screenPoint),Quaternion.identity);
           
        }
      
    }
}
