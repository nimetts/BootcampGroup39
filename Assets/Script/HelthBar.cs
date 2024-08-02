using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
   public Slider slider;
   private GameObject player;
   
   public void SetMHealth(int health){
         slider.maxValue = health;
        slider.value = health;
   }
   public void SetHealth(int health){
        slider.value = health;
   }
}
