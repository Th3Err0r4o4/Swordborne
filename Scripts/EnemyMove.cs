using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] Transform player;
    private UnityEngine.AI.NavMeshAgent nav;
    private Animator anim;

    void Awake()
    {
        Assert.IsNotNull(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
