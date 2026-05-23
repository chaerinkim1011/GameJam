using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondStory : MonoBehaviour
{
    public string[] text = {
        "겨우 없앴네.. 이제 더 없겠...",
        "어겐에 어겐~에 어겐~에 어겐~",
        "??????",
        "어겐에 어겐~에 어겐~에 어겐~",
        "??????????????????",
        "리쓴!!",
        "진짜 왜저러고 살지",
        "이렇게 왜 내가 또? 너의 집압에 또~ 서있는 건~지? 대체 난 바본~지?",
        "하... 왜 내가 쪽팔리지",
        "학생?",
        "네?",
        "폰 안필요하나?",
        "아... 아뇨 괜ㅊ..",
        "하나만 사줘~ 하나에 5만원!",
        "아 필요없다고요!",
        "사라고 이 @#!@^!#$@#$",
        "사달라잖아! 사! 사라고!",
        "아오!!!!"
    };

    public GameObject MCharBad;
    public GameObject MCharSurp;
    public GameObject MCharSigh;

    public GameObject AgainAgain;
    public GameObject JapSang;

    public TMP_Text Texts;
    public TMP_Text Name;
    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MCharBad.gameObject.SetActive(false);
        MCharSigh.gameObject.SetActive(false);
        MCharSurp.gameObject.SetActive(false);

        AgainAgain.gameObject.SetActive(false);
        JapSang.gameObject.SetActive(false);
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
                Name.text = "???";
                MCharSigh.gameObject.SetActive(false);
                AgainAgain.gameObject.SetActive(true);
                break;
            case 2:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                AgainAgain.gameObject.SetActive(false);
                break;
            case 3:
                Name.text = "어게인빌런";
                MCharSurp.gameObject.SetActive(false);
                AgainAgain.gameObject.SetActive(true);
                break;
            case 4:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                AgainAgain.gameObject.SetActive(false);
                break;
            case 5:
                Name.text = "어게인빌런";
                MCharSurp.gameObject.SetActive(false);
                AgainAgain.gameObject.SetActive(true);
                break;
            case 6:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                AgainAgain.gameObject.SetActive(false);
                break;
            case 7:
                Name.text = "어게인빌런";
                MCharSigh.gameObject.SetActive(false);
                AgainAgain.gameObject.SetActive(true);
                break;
            case 8:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                AgainAgain.gameObject.SetActive(false);
                break;
            case 9:
                Name.text = "???";
                MCharSigh.gameObject.SetActive(false);
                JapSang.gameObject.SetActive(true);
                break;
            case 10:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                JapSang.gameObject.SetActive(false);
                break;
            case 11:
                Name.text = "잡상인빌런";
                MCharSurp.gameObject.SetActive(false);
                JapSang.gameObject.SetActive(true);
                break;
            case 12:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                JapSang.gameObject.SetActive(false);
                break;
            case 13:
                Name.text = "잡상인빌런";
                MCharSurp.gameObject.SetActive(false);
                JapSang.gameObject.SetActive(true);
                break;
            case 14:
                Name.text = "나";
                MCharBad.gameObject.SetActive(true);
                JapSang.gameObject.SetActive(false);
                break;
            case 15:
                Name.text = "잡상인빌런";
                MCharSurp.gameObject.SetActive(false);
                JapSang.gameObject.SetActive(true);
                break;
            case 16:
                Name.text = "잡상인빌런";
                JapSang.gameObject.SetActive(true);
                break;
            case 17:
                Name.text = "나";
                MCharBad.gameObject.SetActive(true);
                JapSang.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
