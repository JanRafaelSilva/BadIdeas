using UnityEngine;

public class BotaoTerra : MonoBehaviour
{
    public Animator anim;
    public bool terra = false; 
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ponto"))
        {
            this.gameObject.layer = 8;
            anim.SetBool("Terra", terra);
        }
    }
    public void Receber(bool terra)
    {
        this.terra = terra;
    }
}
