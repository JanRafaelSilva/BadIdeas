using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }
    public void OnParticleSystemStopped()
    {
            GameObject pai = transform.parent.gameObject;
            var a = pai.GetComponent<BotaoPlay>();
            a.Quebrar();
            Destroy(this.gameObject);
        
    }
}
