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

    public override void OnDamaged(int damage)
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
            while((stages.Count > currentStage+1) && ((float)currentHealth/(float)stats.MaxHealth <= stages[currentStage+1]))
            {
                Debug.Log(currentHealth/stats.MaxHealth);
                currentStage++;
                stats = statsPerStage[currentStage];
                monsterStats = monsterStatsPerStage[currentStage];
                animator.SetInteger("stage", currentStage);
            }
        }

        Vector3 direction = (playerManager.activeForm.transform.position.XZPlane() - animator.transform.position.XZPlane()).normalized;
        animator.transform.rotation = Quaternion.LookRotation(direction, animator.transform.up);
        animator.SetBool("inSight", true);

    }
}
