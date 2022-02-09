using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rigid;
    // Update is called once per frame
    private void Start()
    {
        rigid.AddForce(transform.forward * 1000);
    }
}
