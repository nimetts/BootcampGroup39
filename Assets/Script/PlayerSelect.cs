using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button character1Button;
    public Button character2Button;
    public Button character3Button;
    public Button character4Button;

    void Start()
    {
        character1Button.onClick.AddListener(() => SelectCharacter(1));
        character2Button.onClick.AddListener(() => SelectCharacter(2));
        character3Button.onClick.AddListener(() => SelectCharacter(3));
        character4Button.onClick.AddListener(() => SelectCharacter(4));
    }

    void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save();
        Debug.Log("Character " + characterIndex + " selected and saved.");
    }
}