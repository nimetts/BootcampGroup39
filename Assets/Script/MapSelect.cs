using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{
    public Button Map1Button;
    public Button Map2Button;
    public Button Map3Button;
    public Button Map4Button;

    public void Start()
    {
        Map1Button.onClick.AddListener(() => SelectMap(1));
        Map2Button.onClick.AddListener(() => SelectMap(2));
        Map3Button.onClick.AddListener(() => SelectMap(3));
        Map4Button.onClick.AddListener(() => SelectMap(4));
    }

    public void SelectMap(int MapIndex)
    {
        PlayerPrefs.SetInt("SelectedMap", MapIndex);
        PlayerPrefs.Save();
        Debug.Log("Map " + MapIndex + " selected and saved.");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectMap(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectMap(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectMap(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectMap(4);
        }
    }
}