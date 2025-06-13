using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StudyCasting : MonoBehaviour
{
    List<Orc> orcs = new List<Orc>();
    List<Goblin> goblins = new List<Goblin>();
    List<Monster> monsters = new List<Monster>();

    void Start()
    {
        Monster m = new  Monster();
        Monster m2 = new Orc();
        // Orc o1 = m; // 암시적 형변환 불가
        // Orc o2 = (Orc)m; // 명시적 형변환 가능성 있음
        Orc o3 = m as Orc; // 성공 시 형변환, 실패 시 null
        Orc o4 = m2 as Orc;
        
        Debug.Log(o3);
        Debug.Log(o4.GetType());
    }

    void Update()
    {
        
    }
    
    
}
