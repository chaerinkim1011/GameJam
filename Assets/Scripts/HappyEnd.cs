using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HappyEnd : MonoBehaviour
{
    public string[] text = {
        "",
        "그는 수많은 빌런들을 제압하여 서울역까지 올수 있었다.",
        "끄아아... 드디어 서울역이다~",
        "다시는 1호선 안탈거야",
        "시간 잘 맞춰서 왔네요~?",
        "아이~ 당연히 그래야죠~",
        "근데 안색이 왜그래요? 무슨일 있어요?",
        "아, 아무것도 아녜요. 신경쓰지마세요~",
        "그래요 그럼... 가죠~!",
        "썸녀 만날려고 1호선을 뚫고가다니",
        "나도 썸 타고싶다... (또르륵)"
    };

    public GameObject MCharSmile;
    public GameObject MCharSigh;
    public GameObject MCharBad;

    public TMP_Text Texts;
    public TMP_Text Name;

    public Image Bg;
    public Image Bg2;

    public float fadeSpeed = 10f;
    private float alpha = 1f;

    int i = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MCharSmile.gameObject.SetActive(false);
        MCharSigh.gameObject.SetActive(false);
        MCharBad.gameObject.SetActive(false);
        Texts.gameObject.SetActive(false);
        Name.gameObject.SetActive(false);

        SetAlpha(Bg2, 0f);
        SetAlpha(Bg, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Texts.text = text[i];
        if (Input.GetKeyDown(KeyCode.Space)) i++;
        switch (i)
        {
            case 0:
                if (alpha > 0)
                {
                    alpha -= Time.deltaTime * fadeSpeed;

                    // 기존 이미지는 점점 사라짐
                    SetAlpha(Bg, alpha);

                    // 새 이미지는 점점 나타남
                    SetAlpha(Bg2, 1f - alpha);
                }
                break;
            case 1:
                Name.text = "해설";
                Bg2.gameObject.SetActive(false);
                Texts.gameObject.SetActive(true);
                Name.gameObject.SetActive(true);
                break;
            case 2:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(true);
                break;
            case 3:
                Name.text = "나";
                MCharSigh.gameObject.SetActive(false);
                MCharBad.gameObject.SetActive(true);
                break;
            case 4:
                Name.text = "썸녀";
                MCharBad.gameObject.SetActive(false);
                break;
            case 5:
                Name.text = "나";
                MCharSmile.gameObject.SetActive(true);
                break;
            case 6:
                Name.text = "썸녀";
                MCharSmile.gameObject.SetActive(false);
                break;
            case 7:
                Name.text = "나";
                MCharSmile.gameObject.SetActive(true);
                break;
            case 8:
                Name.text = "썸녀";
                MCharSmile.gameObject.SetActive(false);
                break;
            case 9:
                Name.text = "해설";
                break;
            case 10:
                Name.text = "해설ㅠㅠ";
                break;
            default:
                break;
        }
    }

    void SetAlpha(Image img, float a)
    {
        Color color = img.color;
        color.a = Mathf.Clamp01(a);
        img.color = color;
    }
}
