using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStory : MonoBehaviour
{
    public string[] text = {
        "2026년 노을진 어느날 이제 막 퇴근하고 여자친구를 만나러가는 한 청년이 있는데...",
        "어 @@야 지금 막 회사 끝나고 가는중이야~",
        "아, 그래? 알겠어~ 얼른 갈게, 끊어~",
        "크아아~ 드디어 @@이랑 노는구만~ 빨리 가야지~",
        "잠시후...",
        "오~ 지하철 사람 별로 없고~ 자리도 많고~",
        "그런데 그때...",
        "야야! 너 누구야? 누구야? 후아유? 확 씨",
        "예 저요...?",
        "너 까불래? 확! 간수 눈까를 뽀바 버린다 쉬@쉐@드라! ",
        "ㅅㅂ 뭐야...?",
        "콰아아악 그냥 확! 그냥!",
        "(움찔)",
        "안때려! 난 안때려!",
        "하... 인생"
    };

    public GameObject MCharBad;
    public GameObject MCharGood;
    public GameObject MCharSmile;
    public GameObject MCharSurp;
    public GameObject MCharSigh;

    public GameObject Enemy;

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

        Enemy.gameObject.SetActive(false);
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
                Name.text = "나";
                MCharGood.gameObject.SetActive(true);
                break;
            case 2:
                Name.text = "나";
                MCharGood.gameObject.SetActive(true);
                break;
            case 3:
                Name.text = "나";
                MCharSmile.gameObject.SetActive(true);
                MCharGood.gameObject.SetActive(false);
                break;
            case 4:
                Name.text = "해설";
                MCharSmile.gameObject.SetActive(false);
                break;
            case 5:
                Name.text = "나";
                MCharSmile.gameObject.SetActive(true);
                break;
            case 6:
                Name.text = "해설";
                MCharSmile.gameObject.SetActive(false);
                break;
            case 7:
                Name.text = "단소살인마";
                Enemy.gameObject.SetActive(true);
                break;
            case 8:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                Enemy.gameObject.SetActive(false);
                break;
            case 9:
                Name.text = "단소살인마";
                Enemy.gameObject.SetActive(true);
                MCharSurp.gameObject.SetActive(false);
                break;
            case 10:
                Name.text = "나";
                MCharBad.gameObject.SetActive(true);
                Enemy.gameObject.SetActive(false);
                break;
            case 11:
                Name.text = "단소살인마";
                Enemy.gameObject.SetActive(true);
                MCharBad.gameObject.SetActive(false);
                break;
            case 12:
                Name.text = "나";
                MCharSurp.gameObject.SetActive(true);
                Enemy.gameObject.SetActive(false);
                break;
            case 13:
                Name.text = "단소살인마";
                Enemy.gameObject.SetActive(true);
                MCharSurp.gameObject.SetActive(false);
                break;
            case 14:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                Enemy.gameObject.SetActive(false);
                break;
            default:
                SceneManager.LoadScene("InGame");
                break;
        }
    }
}
