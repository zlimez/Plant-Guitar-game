using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Intelitem : MonoBehaviour
{
    public TextMeshProUGUI[] reportHolder;
    public Image[] renderers;

    void Start() {
        SetReport();
    }
    
    public void SetReport() {
        string[] report = LevelManager.GenReport();
        Sprite[] alienImages = LevelManager.GetAlienImages();
        for (int i = 0; i < report.Length; i++) {
            reportHolder[i].SetText(report[i]);
            renderers[i].sprite = alienImages[i];
        }
    }
}
