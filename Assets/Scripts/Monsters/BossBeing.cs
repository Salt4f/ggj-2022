using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBeing : MonsterBeing
{
    public List<float> stages;

    public List<Stats> statsPerStage;
    public List<MonsterStats> monsterStatsPerStage;

    int currentStage;

    public override void Initialize()
    {
        currentStage = 0;
        stats = statsPerStage[currentStage];
        monsterStats = monsterStatsPerStage[currentStage];
        animator.SetInteger("stage", currentStage);
    }

    public override void OnDamaged(float damage)
    {
        Debug.Log("Boss receives " + damage + " damage");

        if(monsterStats.HasDamageReaction) // Check receives dmg
        {
            animator.SetTrigger("attacked");
        }

        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            animator.SetTrigger("dead");
        }
        else
        {
            if(stages.Count > currentStage+1)
            {
                while(stages.Count > currentStage+1 && currentHealth/stats.MaxHealth <= stages[currentStage+1])
                {
                    currentStage++;
                    stats = statsPerStage[currentStage];
                    monsterStats = monsterStatsPerStage[currentStage];
                    animator.SetInteger("stage", currentStage);
                }
            }
        }

    }
}
