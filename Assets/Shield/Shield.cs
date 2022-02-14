using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Material material1;
    Material material2;
    public ShieldtoCam Camcompo;
    public GameObject EffectPrefab1;
    public GameObject EffectPrefab2;
    public GameObject SparkPrefab;
    // Start is called before the first frame update
   
    private void OnCollisionEnter(Collision other)
    {
       
        if(other.gameObject.tag =="Bullet")
        {

            var Target1 =  Instantiate(EffectPrefab1, transform) as GameObject;
            var Target2 = Instantiate(EffectPrefab2, transform) as GameObject;
            var Target3 = Instantiate(SparkPrefab, transform) as GameObject;
            var psr1 = Target1.transform.GetComponent<ParticleSystemRenderer>();
            var psr2 = Target2.transform.GetComponent<ParticleSystemRenderer>();
            var Target2_module = Target2.GetComponent<ParticleSystem>();
            var a = Target2_module.main;
          
           
            material1 = psr1.material;
            material1.SetVector("_Center",other.contacts[0].point);

            material2 = psr2.material;
            Target2.transform.LookAt(other.contacts[0].point);
            Target3.transform.LookAt(other.contacts[0].point);
            Target3.transform.position = other.contacts[0].point;


            material2.SetVector("_Center", other.contacts[0].point);
            StartCoroutine(RadiusRoutine(material1));
            StartCoroutine(Sphere(material2));
            Destroy(Target1, 1.5F);
            Destroy(Target2, 0.7F);
            Destroy(other.gameObject);
            Camcompo.Shieldhit();
        }

    }
    public IEnumerator Sphere(Material mat)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        mat.SetFloat("_Top",Mathf.Clamp(mat.GetFloat("_Top") + Time.deltaTime*2,0,1));
        if (mat.GetFloat("_Top") < 1)
        {
            StartCoroutine(Sphere(mat));
        }
    }

    public IEnumerator RadiusRoutine(Material mat)
    {
        yield return new WaitForSeconds(Time.deltaTime);
        mat.SetFloat("_Radius",mat.GetFloat("_Radius") -Time.deltaTime);
        if(mat.GetFloat("_Radius")>0)
        {
            StartCoroutine(RadiusRoutine(mat));
        }
    }
}
