using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    INode<EnemyContext> rootNode;
    EnemyContext E = new EnemyContext();
    // Start is called before the first frame update
    void Start()
    {
        var attack = new ActionNode<EnemyContext>(Act_Attack);
        var chase = new ActionNode<EnemyContext>(Act_Chase);
        var patrol = new ActionNode<EnemyContext>(Act_Patrol);
        var idle = new ActionNode<EnemyContext>(Act_Idle);

        var idleOrChase = new DecisionNode<EnemyContext>(CanSeePlayer, chase, idle);
        var canAttack = new DecisionNode<EnemyContext>(InAttackRange, attack, idleOrChase);
        rootNode = idleOrChase;

        E.Self = this.transform;
        E.Player = GameObject.Find("Player").transform;
        E.AttackRange = 10;
        E.HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rootNode?.Tick(E);
    }

    void Act_Attack(EnemyContext c)
    {
        // Implement attack logic here
        Debug.Log("Enemy is attacking!");
    }

    void Act_Chase(EnemyContext c)
    {
        Debug.Log("Enemy is chasing the player!");
    }

    void Act_Patrol(EnemyContext c)
    {
        Debug.Log("Enemy is patrolling the area!");
    }

    void Act_Idle(EnemyContext c)
    {
        Debug.Log("Enemy is idle.");
    }


    bool CanSeePlayer(EnemyContext c)
    {
        // Implement logic to determine if the enemy can see the player
        return Vector2.Distance(c.Self.position, c.Player.position) <= c.AttackRange; // Example distance check
    }

    bool InAttackRange(EnemyContext c)
    {
        // Implement logic to determine if the player is within attack range
        return false; // Placeholder return value
    }

    bool loseFocus(EnemyContext c)
    {
        // Implement logic to determine if the enemy loses focus on the player
        return false; // Placeholder return value
    }

    private void OnDrawGizmosSelected() {
         Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(E.Self.position, E.AttackRange);
    } 
}
