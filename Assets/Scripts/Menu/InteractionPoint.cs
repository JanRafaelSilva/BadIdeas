using UnityEngine;
public class InteractionPoint : MonoBehaviour
{
    public Buttons buttons;
    //[SerializeField] private int clicks;
    public void Awake()
    {
        buttons = GetComponent<Buttons>();
    }
    private void Update()
    {
        if(buttons.clicks == 3)
        {
            Debug.Log("funcionou");
            buttons.clicks = 0;
        }
    }
}