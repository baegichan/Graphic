using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldtoCam : MonoBehaviour
{
    public Transform Shield;
    public float Speed;
    private float shieldamount;
    public GameObject image;
    public Transform Canvas;
    private bool Starting;
    private float ysize = 5.5f*2; // max 11
    private float xsize = 9.0f*2; //max 18
    Material material1;
    Camera cam;
    private Vector2 StartVector = new Vector2(0, 0);
    void Start()
    {
        cam = GetComponent<Camera>();
        material1 = image.GetComponent<Image>().material;
        ResetMaterial();
        shieldamount = material1.GetFloat("_Shield");
      
     
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Starting = true;
            StartCoroutine(ShieldOn());
        }
        if (Starting)
        {
            Vector3 screenPos = cam.WorldToScreenPoint(Shield.position);
            StartVector = new Vector2((screenPos.x / Screen.width), (screenPos.y / Screen.height));
            Debug.Log(StartVector);

            material1.SetVector("_Screenposition", new Vector4(-9.0f + StartVector.x * 18 + (Camera.main.transform.position.x), -5.5f + StartVector.y * 11 + Camera.main.transform.position.y, Canvas.position.z));

        }
    }
    public void ResetMaterial()
    {
        material1.SetFloat("_Shield", -1);
        material1.SetFloat("_ShieldOn", 0);
        shieldamount = -1;

    }
    public void Shieldhit()
    {
        StopCoroutine(ShieldOn());
       if(material1.GetInt("_ShieldOn") == 1)
       {
            shieldamount = Mathf.Clamp(shieldamount - 3, 50, 60);
            material1.SetFloat("_Shield", shieldamount);

       }
      StartCoroutine( ShieldOn());
    }
    IEnumerator ShieldOn()
    {
     
       
        yield return new WaitForSeconds(Time.deltaTime);
        if (shieldamount < 60)
        {
            if (material1.GetInt("_ShieldOn") == 0)
            {
                shieldamount = Mathf.Clamp(shieldamount + Time.deltaTime * 20, 0, 60);
            }
            else
            {
                shieldamount = Mathf.Clamp(shieldamount + Time.deltaTime *5, 0, 60);
            }
            material1.SetFloat("_Shield", shieldamount);
            if (shieldamount != 60)
            {
                StartCoroutine(ShieldOn());
            }
            else if (shieldamount == 60)
            {
                material1.SetInt("_ShieldOn", 1);
            }
        }
    }
}
