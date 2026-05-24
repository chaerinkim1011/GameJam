using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject Stage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Stage != null)
        {
            Stage.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClickStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonClickEnd()
    {
        Application.Quit();
    }
    public void OnButtonClickStage()
    {
        if (Stage != null)
        {
            Stage.gameObject.SetActive(true);
        }
    }
    public void OnButtonClickBack()
    {
        if (Stage != null)
        {
            Stage.gameObject.SetActive(false);
        }
    }
    public void OnButtonClickStage1()
    {
        SceneManager.LoadScene("1stStory");
    }
    public void OnButtonClickGoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
