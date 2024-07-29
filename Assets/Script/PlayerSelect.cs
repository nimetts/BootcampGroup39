using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button character1Button;
    public Button character2Button;
    public Button character3Button;
    public Button character4Button;

    public void Start()
    {
        character1Button.onClick.AddListener(() => SelectCharacter(1));
        character2Button.onClick.AddListener(() => SelectCharacter(2));
        character3Button.onClick.AddListener(() => SelectCharacter(3));
        character4Button.onClick.AddListener(() => SelectCharacter(4));
    }

    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();
        Debug.Log("Character " + characterIndex + " selected and saved.");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectCharacter(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectCharacter(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectCharacter(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectCharacter(4);
        }
    }
}