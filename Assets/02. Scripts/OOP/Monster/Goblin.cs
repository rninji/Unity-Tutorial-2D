using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float traceDist = 5f;
    private float attackDist = 1.5f;

    private bool isAttack;
    
    void Start()
    {
        Init(10f, 3f, 2f);
    }

    public override void Idle()
    {
        // 지정 시간 초과 시 Patrol 상태로 변환
        timer += Time.deltaTime;
        if (timer >= stateTime)
            State = MonsterState.PATROL;
        
        // 타겟이 시야에 있고 추격 범위 이내일 경우 상태 전환
        if (targetDist < traceDist && isTrace)
            State = MonsterState.TRACE;
    }

    public override void Patrol()
    {
        timer += Time.deltaTime;
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        
        // 지정 시간 초과 시 Idle 상태로 변환
        if (timer >= stateTime)
            State = MonsterState.IDLE;
        
        // 타겟이 시야에 있고 추격 범위 이내일 경우 상태 전환
        if (targetDist < traceDist && isTrace)
            State = MonsterState.TRACE;
    }

    public override void Trace()
    {
        // 타겟 방향으로 이동
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;
        // 타겟 방향 바라보기
        moveDir = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(moveDir, 1, 1);

        // 범위 벗어나면 Idle로 전환
        if (targetDist > traceDist)
            State = MonsterState.IDLE;
        
        // 공격 범위 이내라면 Attack으로 전환
        if (targetDist < attackDist)
            State = MonsterState.ATTACK;
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
        
        yield return new WaitForSeconds(attackTime);
        isAttack = false;

        State = MonsterState.IDLE;
        // ChangeState(MonsterState.IDLE);
    }
}