using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BadEnd : MonoBehaviour
{
    public string[] text = {
        "그가 탄 지하철은 빌런들 때문에 지연이 심하게 되어서",
        "그는 결국 제시간에 도착하지못하였다.",
        "허억... 허억...",
        "허어,,,? 어디가셨지?",
        "설마 가셨나..?",
        "아... 아.. 안돼!",
        "그는 결국 여자를 잃고 슬픔에 잠겼습니다",
        "역시 솔로천국 커플지옥 우헤헿"
    };

    public GameObject MCharHard;
    public GameObject MCharSad;

    public TMP_Text Texts;
    public TMP_Text Name;
    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MCharHard.gameObject.SetActive(false);
        MCharSad.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Texts.text = text[i];
        if (Input.GetKeyDown(KeyCode.Space)) i++;
        switch (i)
        {
            case 0:
                Name.text = "해설";
                break;
            case 1:
                Name.text = "해설";
                break;
            case 2:
                Name.text = "나";
                MCharHard.gameObject.SetActive(true);
                break;
            case 3:
                Name.text = "나";
                break;
            case 4:
                Name.text = "나";
                break;
            case 5:
                Name.text = "나";
                MCharHard.gameObject.SetActive(false);
                MCharSad.gameObject.SetActive(true);
                break;
            case 6:
                Name.text = "해설";
                MCharSad.gameObject.SetActive(false);
                break;
            case 7:
                Name.text = "해설";
                break;
            default:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
