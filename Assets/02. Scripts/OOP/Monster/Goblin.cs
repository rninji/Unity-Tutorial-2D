using System;
using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    

    private bool isAttack;
    
    void Start()
    {
        Init(30f, 3f, 2f, 10f);
        traceDist = 5f;
        attackDist = 1.5f;
        hpBar.fillAmount = 1;
    }

    public override void Idle()
    {
        // 지정 시간 초과 시 Patrol 상태로 변환
        timer += Time.deltaTime;
        if (timer >= stateTime)
            State = MonsterState.PATROL;
    }

    public override void Patrol()
    {
        // 이동
        timer += Time.deltaTime;
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        
        // 지정 시간 초과 시 Idle 상태로 변환
        if (timer >= stateTime)
            State = MonsterState.IDLE;
    }

    public override void Trace()
    {
        // 타겟 방향으로 이동
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;
        // 타겟 방향 바라보기
        moveDir = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(moveDir, 1, 1);
        hpBar.transform.localScale = new Vector3(moveDir, 1, 1);
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
        // 공격 애니메이션
        isAttack = true;
        animator.SetTrigger("Attack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length; // 애니메이션 길이
        yield return new WaitForSeconds(currAnimLength);
        
        // 공격 쿨다운 - Idle 애니메이션 실행 + Player 바라보기
        Vector3 targetDir = (target.position - transform.position).normalized;
        moveDir = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(moveDir, 1, 1);
        hpBar.transform.localScale = new Vector3(moveDir, 1, 1);
        yield return new WaitForSeconds(attackTime - currAnimLength);
        
        // 추적으로 변경
        isAttack = false;
        State = MonsterState.TRACE;
    }
}