using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    private float idleTime, patrolTime;
    private float percent;
    private float traceDist = 7f;
    private float attackDist = 1.5f;

    private Vector3 startPos, endPos;

    private bool isAttack;
    
    void Start()
    {
        Init(10f, 3f, 2f);
    }

    public override void Idle()
    {
        // 3초 대기 시 Patrol 상태로 변환
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            animator.SetBool("isRun", true);
            
            patrolTime = Random.Range(1f, 5f);

            startPos = transform.position;
            endPos = startPos + Vector3.right * moveDir * patrolTime;
            
            ChangeState(MonsterState.PATROL);
        }

        // 타겟이 추격 범위 이내일 경우 상태 전환
        if (targetDist < traceDist && isTrace)
        {
            
            timer = 0f;
            animator.SetBool("isRun", true);
            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Patrol()
    {
        timer += Time.deltaTime;
        
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        
        // 3초 대기 시 Idle 상태로 변환
        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            animator.SetBool("isRun", false);
            
            idleTime = Random.Range(1f, 5f);
            
            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scalex = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scalex, 1, 1);

        if (targetDist > traceDist)
        {
            animator.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE);
        }

        if (targetDist < attackDist)
        {
            ChangeState(MonsterState.ATTACK);
        }
    }

    public override void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("Attack");
        
        yield return new WaitForSeconds(1f);
        animator.SetBool("isRun", false);
        
        yield return new WaitForSeconds(attackTime - 1f);
        isAttack = false;
        ChangeState(MonsterState.IDLE);
    }
}