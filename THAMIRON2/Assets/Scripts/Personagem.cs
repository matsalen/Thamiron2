using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] BoxCollider hitbox;
    float animLenght;
    bool Atacando;
    Animator anim;
    Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Atacando = false;
        hitbox.enabled = false;
    }

    private void Update()
    {
        if (rbody.IsSleeping())
            rbody.WakeUp();

        if (!Atacando)
            Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Atacando = true;
            Ataque();

        }
        
    }

    protected void Ataque()
    {
        rbody.velocity = Vector3.zero;
        anim.SetBool("Ataque", true);
    }
    protected void Move()
    {

        anim.SetFloat("Velocidade", rbody.velocity.magnitude); ;
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * velocidade, 0, Input.GetAxis("Vertical") * Time.deltaTime * velocidade);
        rbody.velocity = movimento;
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            transform.rotation = Quaternion.LookRotation(movimento);
    }

    protected void terminaAtaque()
    {
        anim.SetBool("Ataque", false);
        Atacando = false;
    }

    protected void HitboxStart()
    {
        hitbox.enabled = true;
    }

    protected void HitboxFinish()
    {
        hitbox.enabled = false;
    }


}
