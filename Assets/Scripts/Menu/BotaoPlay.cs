using Unity.VisualScripting;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using System.Collections;
using System.Collections.Generic;

public class BotaoPlay : MonoBehaviour
{
    [SerializeField] public ParticleSystem ParticleAgua;
    public Buttons play;
    bool ints = true;
    private void Start()
    {
        play = GetComponent<Buttons>(); 
    }
    private void Update()
    {
        if (play.clicks == 3 && play.CanBreak && ints)
        {
            ParticleSystem par = Instantiate(ParticleAgua, ParticleAgua.transform.position, ParticleAgua.transform.rotation);
            par.transform.parent = transform;
            ints = false;
        }
    }
    public void Quebrar()
    {
        Destroy(gameObject);
        Instantiate(play.Particle, transform.position, play.Particle.transform.rotation);
    }
    }
