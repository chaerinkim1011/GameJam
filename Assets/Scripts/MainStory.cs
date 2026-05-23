using TMPro;
using UnityEngine;

public class MainStory : MonoBehaviour
{
    public string[] text = {
        "2026년 노을진 어느날 이제 막 퇴근하고 여자친구를 만나러가는 한 청년이 있는데...",
        "어 @@야 지금 막 회사 끝나고 가는중이야~",
        "아, 그래? 알겠어~ 얼른 갈게, 끊어~",
        "크아아~ 드디어 @@이랑 노는구만~ 빨리 가야지~",
        "잠시후...",
        "오~ 지하철 사람 별로 없고~ 자리도 많고~",
        "그런데 그때...",
        "아아! 확! 거기 너!",
        "예 저요...?",
        "그래 너 앉아! 어이! 앉아!!",
        "ㅅㅂ 뭐야...?",
        "콰아아악 그냥 확! 그냥!",
        "움찔",
        "안때려잇! 확 안때려~!",
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
        if (i == 1 || i == 2)
        {
            MCharGood.gameObject.SetActive(true);
        }
        if(i == 3 || i == 5)
        {
            MCharSmile.gameObject.SetActive(true);
            MCharGood.gameObject.SetActive(false);
        }
        if(i == 8 || i == 12)
        {
            MCharSurp.gameObject.SetActive(true);
            Enemy.gameObject.SetActive(false);
        }
        if(i == 10)
        {
            MCharBad.gameObject.SetActive(true);
            Enemy.gameObject.SetActive(false);
        }
        if(i == 7 || i == 9 || i == 11 || i == 13)
        {
            Enemy.gameObject.SetActive(true);
            MCharBad.gameObject.SetActive(false);
            MCharSmile.gameObject.SetActive(false);
            MCharSurp.gameObject.SetActive(false);
        }
        if(i == 14)
        {
            MCharSigh.gameObject.SetActive(true);
            Enemy.gameObject.SetActive(false);
        }

        if(i == 0 || i == 4 || i == 6)
        {
            Name.text = "해설";
            MCharSmile.gameObject.SetActive(false);
        }
        else if(i == 7 || i == 9 || i == 11 || i == 13)
        {
            Name.text = "단소살인마";
        }
        else
        {
            Name.text = "나";
        }

    }
}
