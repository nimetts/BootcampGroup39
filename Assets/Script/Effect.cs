using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="status effect")]

public class Effect : ScriptableObject
{
   public string effectN;
   public int  Amount;
   public float  TickSpeed;
   public float  Movements;
   public float  lifetTime;
}
