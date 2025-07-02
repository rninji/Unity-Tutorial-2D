using System;
using UnityEngine;

public interface IItemObject
{ 
     ItemManager Manager { get; set; }
     GameObject Obj { get; set; } 
     string itemName { get; set; } 
     Sprite Icon { get; set; }
     
     void Get(); 
     void Use();
}
