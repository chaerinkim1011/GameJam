using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public GameObject Settings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Settings.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClickSet()
    {
        Settings.gameObject.SetActive(true);
    }
    public void OnButtonClickGoHome()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonClickContinue()
    {
        Settings.gameObject.SetActive(false);
    }
}
