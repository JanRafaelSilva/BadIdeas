using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class Destroyer : MonoBehaviour
{
    public bool play = false;
    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }
    public void test()
    {
        if (!play)
        {
            Debug.Log("a");
            Destroy(this.gameObject);
        }
    }
    public void OnParticleSystemStopped()
    {
        if (play)
        {
            GameObject pai = transform.parent.gameObject;
            var a = pai.GetComponent<BotaoPlay>();
            a.Quebrar();
            Destroy(this.gameObject);
        }
    }
}
