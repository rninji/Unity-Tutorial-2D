using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
   public enum MonsterState { IDLE, PATROL, TRACE, ATTACK}
   public MonsterState monsterState = MonsterState.IDLE;

   public ItemManager itemManager;

   protected Animator animator;
   protected Rigidbody2D monsterRb;
   protected Collider2D monsterColl;

   public Transform target;
   protected float targetDist;
   protected bool isTrace;
   
   protected float traceDist;
   protected float attackDist;

   public float hp;
   public float speed;
   public float attackTime;
   public float atkDamage;
   
   public float currHp;

   public Image hpBar;
   
   public float moveDir = 1;

   protected float stateTime;
   protected float timer;
   protected Vector3 startPos, endPos;

   private bool isDead;
   
   public MonsterState State
   {
      get { return monsterState; }
      set
      {
         monsterState = value;
         timer = 0f;
         switch (monsterState)
         {
            case MonsterState.IDLE:
               // 지속 시간 지정
               stateTime = Random.Range(1f, 5f);
               animator.SetBool("isRun", false);
               break;
            
            case MonsterState.PATROL:
               // 지속 시간 지정
               stateTime = Random.Range(1f, 5f);
               // 방향 지정
               // moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
               // transform.localScale = new Vector3(moveDir, 1, 1);
               // // 이동 위치 지정
               // startPos = transform.position;
               // endPos = startPos + Vector3.right * moveDir * stateTime;
               
               animator.SetBool("isRun", true);
               break;
            
            case MonsterState.TRACE:
               animator.SetBool("isRun", true);
               break;
            
            case MonsterState.ATTACK:
               animator.SetBool("isRun", false);
               break;
         }
      }
   }

   protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
   {
      this.hp = hp;
      this.speed = speed;
      this.attackTime = attackTime;
      this.atkDamage = atkDamage;
      currHp = hp;

      animator = GetComponent<Animator>();
      monsterRb = GetComponent<Rigidbody2D>();
      monsterColl = GetComponent<Collider2D>();

      target = GameObject.FindGameObjectWithTag("Player").transform;

      itemManager = FindFirstObjectByType<ItemManager>();
   }

   void Update()
   {
      if (isDead) return;
      
      StartCoroutine(FindPlayerRoutine());
      
      switch (monsterState)
      {
         case MonsterState.IDLE:
            Idle();
            break;
         case MonsterState.PATROL:
            Patrol();
            break;
         case MonsterState.TRACE:
            Trace();
            break;
         case MonsterState.ATTACK:
            Attack();
            break;
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Return"))
      {
         moveDir *= -1;
         transform.localScale = new Vector3(moveDir, 1, 1);
         hpBar.transform.localScale = new Vector3(moveDir, 1, 1);
      }

      if (other.GetComponent<IDamageable>() != null)
      {
         other.GetComponent<IDamageable>().TakeDamage(atkDamage);
      }
   }

   public abstract void Idle();
   public abstract void Patrol();
   public abstract void Trace();
   public abstract void Attack();
   
   IEnumerator FindPlayerRoutine()
   {
      yield return null;
      targetDist = Vector3.Distance(transform.position, target.position);
      
      Vector3 monsterDir = Vector3.right * moveDir;
      Vector3 playerDir = (target.position - transform.position).normalized;

      isTrace = Vector3.Dot(monsterDir, playerDir) > 0;

      // Idle, Patrol -> Trace
      if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
      {
         // 범위 내, 시야 내 타겟이 있을 경우 Trace 상태로 전환
         if (targetDist < traceDist && isTrace)
            State = MonsterState.TRACE;
      }
      // Trace -> Idle, Attack
      else if (monsterState == MonsterState.TRACE)
      {
         // 범위 벗어나면 Idle로 전환
         if (targetDist > traceDist)
            State = MonsterState.IDLE;
        
         // 공격 범위 이내라면 Attack으로 전환
         if (targetDist < attackDist)
            State = MonsterState.ATTACK;
      }
   }

   public void TakeDamage(float damage)
   {
      animator.SetTrigger("Hit");
      currHp -= damage;

      hpBar.fillAmount = currHp / hp; // 현재체력 / 최대체력
        
      if (currHp <= 0f)
         Death();
   }

   public void Death()
   {
      animator.SetTrigger("Death");
      monsterColl.enabled = false;
      monsterRb.gravityScale = 0;
      isDead = true;

      // 아이템 드롭
      int itemCount = Random.Range(0, 3);
      if (itemCount > 0)
      {
         for (int i = 0; i < itemCount; i++)
         {
            itemManager.DropItem(transform.position);
         }
      }
   }
}
