using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMaterial : MonoBehaviour
{
    Material material1;
    private float s_size = 0;
    public float max_s_size = 3;
    public void MeshSetting(Mesh mesh)
    {
        ParticleSystemRenderer psr1 = GetComponent<ParticleSystemRenderer>();
        psr1.mesh = mesh;
        material1 = psr1.material;
       
    }
    public void SetPosition(Vector3 point)
    {
        material1.SetVector("_ObjectPosition", point);
    }
   public void StartRoutine()
   {

        StartCoroutine(SphereSizeUp(material1));

    }
    public IEnumerator SphereSizeUp(Material mat)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        if (max_s_size > s_size)
        {
            s_size = Mathf.Clamp(s_size + Time.deltaTime, 0, max_s_size);
            mat.SetFloat("_Mask", s_size);
            StartCoroutine(SphereSizeUp(mat));
        }
        if(max_s_size==s_size)
        {
            Destroy(gameObject,3);
        }
     
    }
}
