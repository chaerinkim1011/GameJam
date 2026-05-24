using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text TimeTxt;
    public int Min;
    public int Sec;
    public float time = 180f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sec = (int)time % 60;
        Min = (int)time / 60;
        TimeTxt.text = Min.ToString("00") + ":" + Sec.ToString("00");
        if (time > 0) time -= Time.deltaTime;
        else SceneManager.LoadScene("2ndStory");
    }
}
