using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private List<string> _tagToDamage ;
    [SerializeField] private int _damage ;
    public List<string> TagToDamage
    {
        get { return _tagToDamage; }
    }
    
    public int Damage
    {
        get { return _damage; }
    }
    
}