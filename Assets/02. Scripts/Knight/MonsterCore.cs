using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class MonsterCore : MonoBehaviour
{
   public enum MonsterState { IDLE, PATROL, TRACE, ATTACK}
   public MonsterState monsterState = MonsterState.IDLE;

   protected Animator animator;
   protected Rigidbody2D monsterRb;
   protected Collider2D monsterColl;

   public Transform target;
   protected float targetDist;
   protected bool isTrace;

   public float hp;
   public float speed;
   public float attackTime;
   
   public float moveDir = 1;

   protected float stateTime;
   protected float timer;
   protected Vector3 startPos, endPos;
   
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
               moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
               transform.localScale = new Vector3(moveDir, 1, 1);
               // 이동 위치 지정
               startPos = transform.position;
               endPos = startPos + Vector3.right * moveDir * stateTime;
               
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

   protected virtual void Init(float hp, float speed, float attackTime)
   {
      this.hp = hp;
      this.speed = speed;
      this.attackTime = attackTime;

      animator = GetComponent<Animator>();
      monsterRb = GetComponent<Rigidbody2D>();
      monsterColl = GetComponent<Collider2D>();

      target = GameObject.FindGameObjectWithTag("Player").transform;
   }

   void Update()
   {
      targetDist = Vector3.Distance(transform.position, target.position);
      
      Vector3 monsterDir = Vector3.right * moveDir;
      Vector3 playerDir = (target.position - transform.position).normalized;

      isTrace = Vector3.Dot(monsterDir, playerDir) > 0;
      
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
      }
   }

   public abstract void Idle();
   public abstract void Patrol();
   public abstract void Trace();
   public abstract void Attack();

   public void ChangeState(MonsterState newState)
   {
      if (monsterState != newState)
         monsterState = newState;
   }
}
