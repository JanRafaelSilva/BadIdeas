using Unity.VisualScripting;
using UnityEngine;

public class VirarGrama : MonoBehaviour
{
    Animator anim;
    bool grama = false;
    bool miniPlayer = false;
    float timer;
    public GameObject Player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnParticleCollision(GameObject ob)
    {
        if(ob.gameObject.layer == 9 && !grama)
        {
            grama = true;
            anim.SetBool("Collision", grama);
        }

    }
    private void Update()
    {
        if (grama)
        {
            timer += Time.deltaTime;
            float timeAnim = anim.GetCurrentAnimatorStateInfo(0).length;
            if(timer > (timeAnim - timeAnim / 8) && !miniPlayer)
            {
                Instantiate(Player, transform.position, Quaternion.identity);
                miniPlayer = true;
            }
        }
    }
}
