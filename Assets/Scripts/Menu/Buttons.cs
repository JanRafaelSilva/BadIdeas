using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool moveButton = false;
    public bool CanBreak = false; // Variavel que ativa o modo quebravel dos botões
    private Animator buttonsAnime;
    public float duracao;
    public float timer;
    [SerializeField]public int clicks;
    private void Awake()
    {
        buttonsAnime = GetComponent<Animator>();
    }
    public void OnClick()
    {
        if (CanBreak)
        {
            clicks++;
            buttonsAnime.SetInteger("BrokeEstage", clicks);
        }
        else if (moveButton == false)
        {
            moveButton = true;
           clicks += 1;
        }
    }
    public void Update()
    {
        if(clicks == 4)
        {
            clicks = 0;
        }
        if (moveButton)
        {
            timer += Time.deltaTime;
            buttonsAnime.SetBool("Touch", moveButton);
            duracao = buttonsAnime.GetCurrentAnimatorStateInfo(0).length;
        }
        if (timer > duracao)
        {
            moveButton = false;
            buttonsAnime.SetBool("Touch", moveButton);
            timer = 0f;
        }
    }
    public void StartBreak()
    {
        clicks = 0;
        CanBreak = true;
        buttonsAnime.SetBool("Broking", CanBreak);
    }
}
