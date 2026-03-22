using UnityEditor;
using UnityEngine;

public class Erupção : MonoBehaviour
{
    Rigidbody2D rb;
    bool erupcao = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        if(erupcao == false && rb.linearVelocityY < 8f)
        {
            rb.AddForceY(20f, ForceMode2D.Impulse);
        }
        else
        {
            erupcao = true;
        }
    }
}
