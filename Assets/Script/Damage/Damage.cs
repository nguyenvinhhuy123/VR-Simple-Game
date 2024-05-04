using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    [SerializeField] private int m_Damage;
    public int DamageValue {get {return m_Damage;} set {m_Damage = value;}}
    [SerializeField] private Collider m_colliderToIgnore;
    // Start is called before the first frame update
    void Awake() 
    {
        
    }
    void Start()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.gameObject.name + " Collide with " + other.gameObject.name);
        Debug.Log(m_colliderToIgnore);
        Debug.Log(other.collider == m_colliderToIgnore);
        if (other.collider == m_colliderToIgnore) return;
        //TODO: Collision mechanism connected to Damagaeble
        if (other.gameObject.TryGetComponent<Health>(out Health heathRef))
        {
            heathRef.Damaged(m_Damage, gameObject.GetComponent<Damage>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + " Collide with " + other);
        if (other == m_colliderToIgnore) return;
        if (other.gameObject.layer.ToString() == "Weapon") return;
        Debug.Log(m_colliderToIgnore);
        Debug.Log(other == m_colliderToIgnore);
        //TODO: Collision mechanism connected to Damagaeble
        if (other.gameObject.TryGetComponent<Health>(out Health heathRef))
        {
            heathRef.Damaged(m_Damage, gameObject.GetComponent<Damage>());
        }
        else
        {
            Health parentHealthRef = other.gameObject.GetComponentInParent<Health>();
            if (parentHealthRef != null)
            {   
                parentHealthRef.Damaged(m_Damage, gameObject.GetComponent<Damage>());
            }
            
        }
    }
    public void SetIgnore(Collider ignore)
    {
        m_colliderToIgnore = ignore;
        Physics.IgnoreCollision(m_colliderToIgnore, GetComponent<Collider>());
    }
}
