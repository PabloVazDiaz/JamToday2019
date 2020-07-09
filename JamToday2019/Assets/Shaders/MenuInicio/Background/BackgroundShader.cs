using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShader : MonoBehaviour
{


    //public float fade = 0f;

    public bool active = false;

    Material material;
    void Start()
    {
            material = GetComponent<SpriteRenderer>().material;

        material.SetFloat("_ClickBackground", 0f);

    }

    public void CallTOxic()
    {
        StartCoroutine(Toxic());
    }

   public IEnumerator Toxic()
    {
            float toxic = 0f;

        while(material.GetFloat("_ClickBackground") < 1f)
        {
            material.SetFloat("_ClickBackground", toxic );
            yield return new WaitForEndOfFrame();
            toxic += Time.deltaTime;
        }
    }
    
}
