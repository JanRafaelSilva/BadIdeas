using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool moveButton = false;
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
        if (moveButton == false)
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
}
