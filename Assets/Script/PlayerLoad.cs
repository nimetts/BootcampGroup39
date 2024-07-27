using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject character1Prefab;
    public GameObject character2Prefab;
    public GameObject character3Prefab;
    public GameObject character4Prefab;

    void Start()
    {
        LoadCharacter();
    }

    void LoadCharacter()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 1); // Default to character 1
        GameObject characterToSpawn = null;

        switch (selectedCharacter)
        {
            case 1:
                characterToSpawn = character1Prefab;
                break;
            case 2:
                characterToSpawn = character2Prefab;
                break;
            case 3:
                characterToSpawn = character3Prefab;
                break;
            case 4:
                characterToSpawn = character4Prefab;
                break;
            default:
                characterToSpawn = character1Prefab;
                break;
        }

        if (characterToSpawn != null)
        {
            Instantiate(characterToSpawn, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("No character prefab found for the selected character.");
        }
    }
}