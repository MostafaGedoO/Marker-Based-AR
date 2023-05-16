using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
   [Header("Matirals")] 
   [SerializeField] private Material mainCarMat;
   [SerializeField] private List<Material> lightMats;

   [Header("Sounds")] 
   [SerializeField] private AudioSource carSound;

   [Header("Control Values")] 
   [SerializeField] private float rotateSpeed = 30f;
   [SerializeField] private float scaleSpeed = 0.1f;
   
   private float localScale;
   private bool isLightsON;
   
   private bool isRotateLeft;
   private bool isRotateRight;
   private bool isScaleUp;
   private bool isScaleDown;

   private void Update()
   {
      if (isScaleUp)
      {
         transform.localScale += Time.deltaTime * Vector3.one * scaleSpeed;
         localScale = transform.localScale.x;
      }

      if (isScaleDown)
      {
         if (localScale > 0.02f)
         {
            transform.localScale -= Time.deltaTime * Vector3.one * scaleSpeed;
            localScale = transform.localScale.x;
         }
      }

      if (isRotateLeft)
      {
         transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
      }
      
      if (isRotateRight)
      {
         transform.Rotate(-Vector3.up * Time.deltaTime * rotateSpeed);
      }
   }

   #region bools

   public void StartScaleUp()
   {
      isScaleUp = true;
   }

   public void StopScaleUp()
   {
      isScaleUp = false;
   } 
   
   public void StartScaleDown()
   {
      isScaleDown = true;
   }

   public void StopScaleDown()
   {
      isScaleDown = false;
   }  
   
   public void StartRotateLeft()
   {
      isRotateLeft = true;
   }

   public void StopRotateLeft()
   {
      isRotateLeft = false;
   } 
   
   public void StartRotateRight()
   {
      isRotateRight = true;
   }

   public void StopRotateRight()
   {
      isRotateRight = false;
   }
   

   #endregion
   
   private void Start()
   {
      localScale = transform.localScale.x;
   }
   
   
   public void ChangeCarColor(int colorNum)
   {
      if (colorNum == 0) mainCarMat.color = Color.red;
      if (colorNum == 1) mainCarMat.color = Color.blue;
      if (colorNum == 2) mainCarMat.color = Color.green;
      if (colorNum == 3) mainCarMat.color = Color.yellow;
      if (colorNum == 4) mainCarMat.color = Color.black;
      if (colorNum == 5) mainCarMat.color = Color.white;
   }

   public void ToggleLight()
   {
      if (!isLightsON)
      {
         isLightsON = true;
         foreach (var lightMat in lightMats)
         {
            lightMat.SetColor("_EmissionColor", Color.white * 2);
         }
      }
      else
      {
         isLightsON = false; 
         foreach (var lightMat in lightMats)
         {
            lightMat.SetColor("_EmissionColor", Color.black);
         }
      }
   }

   public void PlaySound()
   {
      carSound.Play();
   }
   
}
