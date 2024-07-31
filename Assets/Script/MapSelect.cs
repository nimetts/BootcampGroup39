using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapSelect : MonoBehaviour
{
    public Button Map1Button;
    public Button Map2Button;
    public Button Map3Button;
    public Button Map4Button;

    private bool mapSelected = false;

    void Start()
    {
        Map1Button.onClick.AddListener(() => SelectMap(1));
        Map2Button.onClick.AddListener(() => SelectMap(2));
        Map3Button.onClick.AddListener(() => SelectMap(3));
        Map4Button.onClick.AddListener(() => SelectMap(4));
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

        if (mapSelected && Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoadSelectedMapAfterDelay(3f));  // 3 saniye gecikmeyle yükle
        }
    }

    public void SelectMap(int MapIndex)
    {
        PlayerPrefs.SetInt("SelectedMap", MapIndex);
        PlayerPrefs.Save();
        Debug.Log("Map " + MapIndex + " selected and saved.");
        mapSelected = true;
    }

    private IEnumerator LoadSelectedMapAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        int selectedMap = PlayerPrefs.GetInt("SelectedMap", 1);  // Varsayılan olarak 1. harita yüklenir
        string sceneName = "Map" + selectedMap;
        SceneManager.LoadScene(sceneName);
    }
}