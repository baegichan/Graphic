using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScan : MonoBehaviour
{
   
    public GameObject EffectPrefab1;
    Mesh Mesh;

    private float s_size=0;
    public float max_s_size = 3;
    // Start is called before the first frame update
    void Start()
    {
         if (GetComponent<MeshFilter>().mesh!=null)
        {
            Mesh = GetComponent<MeshFilter>().mesh;
        }
  
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Bullet")
        { 
            GameObject Target1 = Instantiate(EffectPrefab1, transform);
            if (Target1.GetComponent<ParticleSystem>() != null)
            {
                Target1.GetComponent<ScanMaterial>().MeshSetting(GetComponent<MeshFilter>().mesh);
                Target1.GetComponent<ScanMaterial>().SetPosition(other.contacts[0].point);

                Target1.GetComponent<ScanMaterial>().StartRoutine();
            }
            }

        }
}
