using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("Parallax Arka Planlarý")]
    [SerializeField] public GameObject snowParallax;
    [SerializeField] public GameObject summerParallax;
    [SerializeField] public GameObject desertParallax;
    [SerializeField] public GameObject graveyardParallax;

    [Header("Arka plan deðiþim hýzý")]
    public float backgroundtickerfast = 3f;

    private int currentParallax = 0;

    void Start()
    {
        StartCoroutine(ChangeParallax());
    }


    #region Parallax Background Activate Fonk.
    public void SnowActive()
    {
        snowParallax.SetActive(true);
        summerParallax.SetActive(false);
        desertParallax.SetActive(false);
        graveyardParallax.SetActive(false);
    }

    public void SummerActive()
    {
        snowParallax.SetActive(false);
        summerParallax.SetActive(true);
        desertParallax.SetActive(false);
        graveyardParallax.SetActive(false);
    }

    public void DesertActive()
    {
        snowParallax.SetActive(false);
        summerParallax.SetActive(false);
        desertParallax.SetActive(true);
        graveyardParallax.SetActive(false);
    }

    public void GraveyardActive()
    {
        snowParallax.SetActive(false);
        summerParallax.SetActive(false);
        desertParallax.SetActive(false);
        graveyardParallax.SetActive(true);
    }
    #endregion

    #region Parallax Couritine
    private IEnumerator ChangeParallax()
    {
        while (true)
        {
            yield return new WaitForSeconds(backgroundtickerfast);

            currentParallax = (currentParallax + 1) % 4;

            switch (currentParallax)
            {
                case 0:
                    SnowActive();
                    break;
                case 1:
                    SummerActive();
                    break;
                case 2:
                    DesertActive();
                    break;
                case 3:
                    GraveyardActive();
                    break;
            }
        }
    }
    #endregion
}
