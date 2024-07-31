using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public float winTime = 300f; // 5 dakika = 300 saniye
    private float elapsedTime = 0f;
    private bool gameWon = false;
    
    public Text winText; // Kazanma mesajını göstermek için UI Text bileşeni
    public Text timerText; // Geri sayım sayacını göstermek için UI Text bileşeni

    void Start()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(false); // Başlangıçta kazanç mesajını gizle
        }
    }

    void Update()
    {
        if (!gameWon)
        {
            elapsedTime += Time.deltaTime; // Geçen süreyi artır
            float remainingTime = winTime - elapsedTime; // Kalan süreyi hesapla

            if (timerText != null)
            {
                // Kalan süreyi dakika ve saniye formatında güncelle
                int minutes = Mathf.FloorToInt(remainingTime / 60F);
                int seconds = Mathf.FloorToInt(remainingTime % 60F);
                timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            }

            if (remainingTime <= 0)
            {
                WinGame();
            }
        }
    }

    void WinGame()
    {
        gameWon = true;

        // Kazanma mesajını göster
        if (winText != null)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";
        }

        // Oyunu durdur (isteğe bağlı)
        Time.timeScale = 0f;
    }
}