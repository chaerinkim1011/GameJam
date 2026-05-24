using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdStory : MonoBehaviour
{
    public string[] text = {
        "하... 진짜 오늘 일진 왜이래?",
        "단소 달고 있지않나...",
        "헤드셋 쓰고 노랠 크게 부르질않나",
        "중고폰, 대포폰 달고 다니면서 팔고 앉아있고...",
        "이번엔 제발 평범하게 가게 해주세요...",
        "하지만 그의 희망은 개나 줘버리고 또다른 빌런이 나오는데...",
        "동시에 타격해야 하느니라",
        "???",
        "이 천둥, 좌우상하 동시에",
        "콰가과가광 꽝쾅!!!!!!!",
        "아아니이익!!!!!!!!",
    };

    public GameObject MCharBad;
    public GameObject MCharSurp;
    public GameObject MCharSigh;
    public GameObject MCharMad;

    public GameObject Jarban;

    public TMP_Text Texts;
    public TMP_Text Name;
    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MCharBad.gameObject.SetActive(false);
        MCharSigh.gameObject.SetActive(false);
        MCharSurp.gameObject.SetActive(false);
        MCharMad.gameObject.SetActive(false);

        Jarban.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Texts.text = text[i];
        if (Input.GetKeyDown(KeyCode.Space)) i++;
        switch (i)
        {
            case 0:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                break;
            case 1:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(false);
                MCharBad.gameObject.SetActive(true);
                break;
            case 2:
                Name.text = "나";
                break;
            case 3:
                Name.text = "나";
                break;
            case 4:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                MCharBad.gameObject.SetActive(false);
                break;
            case 5:
                Name.text = "해설";
                MCharSigh.gameObject.SetActive(false);
                break;
            case 6:
                Name.text = "???";
                Jarban.gameObject.SetActive(true);
                break;
            case 7:
                Name.text = "나";
                Jarban.gameObject.SetActive(false);
                MCharSurp.gameObject.SetActive(true);
                break;
            case 8:
                Name.text = "자르반84세";
                Jarban.gameObject.SetActive(true);
                MCharSurp.gameObject.SetActive(false);
                break;
            case 9:
                Name.text = "자르반84세";
                break;
            case 10:
                Name.text = "나";
                Jarban.gameObject.SetActive(false);
                MCharMad.gameObject.SetActive(true);
                break;
            default:
                SceneManager.LoadScene("Round3");
                break;
        }
    }
}
