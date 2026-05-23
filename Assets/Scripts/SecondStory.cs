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
        "하... 옘병",
        "아이 이거 삭"
    };

    public GameObject MCharBad;
    public GameObject MCharGood;
    public GameObject MCharSmile;
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
        MCharGood.gameObject.SetActive(false);
        MCharSmile.gameObject.SetActive(false);
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
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            default:
                break;
        }
    }
}
