using System.Threading;
using UnityEngine;
public class InteractionPoint : MonoBehaviour
{
    public Buttons buttons;
    public bool cair = false;
    Rigidbody2D rb;
    public Animator anima;
    float timer;
    public void Awake()
    {
        buttons = GetComponent<Buttons>();
        anima = GetComponent<Animator>();
    }
    public void Update()
    {
        if (buttons.clicks == 3)
        {
            timer += Time.deltaTime;
            anima.SetBool("Semente", true);
            float timeAnim = anima.GetCurrentAnimatorStateInfo(0).length;
            this.buttons.enabled = false;
            if (timer >= timeAnim)
            {
                cair = true;
                gameObject.AddComponent<Rigidbody2D>();
                rb = GetComponent<Rigidbody2D>();
                this.anima.enabled = false;
                rb.AddForce((Vector2.up * 2.5f), ForceMode2D.Impulse);
                buttons.clicks = 0;
                timer = 0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("BotãoTerra"))
        {

        }
    }
}