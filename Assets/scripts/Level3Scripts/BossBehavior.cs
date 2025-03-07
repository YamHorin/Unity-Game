using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossBehavior : MonoBehaviour ,IDamageable
{
    public float health = 100;
    public GameObject player;
    NavMeshAgent agent;
    Animator anim;
    bool isFighting = false;
    public Image healthBar;
    public float attackDistance = 1;
    float currentHealth;


    //for the attack cool down 
    float lastAttackTime = 1;
    float attackCoolDown = 3;

    float lastTuantTime = 0;
    float TuantCoolDown = 5;

    public void TakeDamage(float damage)
    {
        if (isFighting)
        { 
            currentHealth -= damage;
            Debug.Log("Boss health " + currentHealth);
            StartCoroutine( updateHealthBar());
            if (currentHealth <= 0)
            {
                StartCoroutine( Die());
            }
        }
    }


    IEnumerator Die()
    {
        isFighting = false;
        agent.isStopped = true;
        anim.SetTrigger("die");
        yield return new WaitForSeconds(3);
        staticInfo.isBossDefeted = true;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        DialogManagerLevel3.startBattle+= startBattle;
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFighting)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            //Debug.Log("distance " + distance);
            if (distance >attackDistance)
            {
                agent.isStopped = false;
                agent.SetDestination(player.transform.position);
             
                anim.SetInteger("state",0);
            }
            else
            {
                agent.isStopped = true;
                if (Time.time - lastAttackTime > attackCoolDown)
                {
                    lastAttackTime = Time.time;
                    anim.SetInteger("state", 1);
                    player.GetComponent<IDamageable>().TakeDamage(10);
                }
                if (Time.time - lastTuantTime > TuantCoolDown)
                {
                    lastTuantTime = Time.time;
                    StartCoroutine(taunt());
                }
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
    IEnumerator taunt()
    {
        agent.isStopped = true;
        anim.SetTrigger("taunt");
        yield return new WaitForSeconds(3);
        
    }

    void startBattle()
    {
        StartCoroutine( shrink());
        
    }
    IEnumerator shrink()
    {
        float scale = 30;
        while (scale >2)
        {
            Debug.Log("scale " + scale);
            transform.localScale = new Vector3(scale, scale, scale);
            yield return new WaitForSeconds(3f);
            scale -=5;
        }
        isFighting = true;
        anim.SetTrigger("startBattle");
    }
    IEnumerator updateHealthBar()
    {
        float targetFillAmount = currentHealth / health;
        float currentFillAmount = healthBar.fillAmount;
        while (currentFillAmount > targetFillAmount)
        {
            currentFillAmount -= Time.deltaTime;
            healthBar.fillAmount = currentFillAmount;
            yield return new WaitForSeconds(0.001f);

        }
        healthBar.fillAmount = targetFillAmount;
    }
}
