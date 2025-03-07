using System.Collections;
using UnityEngine;


using UnityEngine.AI;
using UnityEngine.Audio;
public class ZombieBehavior : MonoBehaviour, IDamageable
{

    public GameObject player;
    [Header("info NPC")]
    float health;
    public float damage= 10;
    public float attackDistance = 1;
    public float maxHealth = 100;
    public float walkDistance = 10;

    [Header("targets for the agent")]
    public GameObject target1;
    public GameObject target2;


    [Header("sound distance")]

    public float minDistance = 1f; // Minimum distance for audio adjustments
    public float maxDistance = 5f; // Maximum distance for audio adjustments

    float distance;
    NavMeshAgent agent;
    AudioSource audioSource;
    Animator anim;

    //for the attack cool down 
    float lastAttackTime = 3;
    float attackCoolDown = 3;

    //target for the agent
    int currentTarget = 1;
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Zombie took damage" + health);
        if (health <= 0) {
            StartCoroutine(Die());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        makeTarget();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= attackDistance)
        {
            agent.isStopped = true;
            anim.SetInteger("state", Random.Range(1, 2)); //1 for kick 2 for punch 
            if (Time.time - lastAttackTime > attackCoolDown)
            {
                lastAttackTime = Time.time;
                var damageable = player.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
            }
        }
        else if (distance > attackDistance && distance < walkDistance)
        {
            anim.SetInteger("state", 0); //1 for kick 2 for punch 0 for walk 
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }

        else
        {
            anim.SetInteger("state", 0); //1 for kick 2 for punch 

            if (Vector3.Distance(target2.transform.position, transform.position) < 3 || Vector3.Distance(target1.transform.position, transform.position) < 3)
            { 
                makeTarget();
                
            } 


        }
        HandleAudio(distance);
    }
    void HandleAudio(float distance)
    {
        if (distance <= maxDistance)
        {
            float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
            audioSource.volume = Mathf.Lerp(1f, 0f, normalizedDistance);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private IEnumerator Die()
    {
        anim.SetTrigger("die");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private GameObject makeTarget()
    { 
        agent.isStopped = true;
        switch (currentTarget)
        {
            case 1:
                agent.isStopped = false;
                agent.SetDestination(target1.transform.position);
                currentTarget = 2;
                return target1;
            case 2:
                agent.isStopped = false;
                agent.SetDestination(target2.transform.position);
                currentTarget = 1;
                return target2;
            default:
                agent.isStopped = false;
                agent.SetDestination(target1.transform.position);
                return target1;
        }
        
    }

}
