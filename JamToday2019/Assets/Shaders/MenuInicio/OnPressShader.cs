using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPressShader : MonoBehaviour
{
    Material material;
  
  


    void Start()
    {
        material = GetComponent<Image>().material;
        material.SetFloat("_Slider", 0f);
        material.SetFloat("_Click", 0f);
    }

  public void ActivateShader()
    {
        material.SetFloat("_Slider", 1f);
      
    }

    public void DeactivateShader()
    {
        material.SetFloat("_Slider", 0f);

    }

    public void ClickShader()
    {
        material.SetFloat("_Click", 1f);

    }

}
