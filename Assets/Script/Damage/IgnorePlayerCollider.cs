using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollider : MonoBehaviour
{
    [SerializeField] private Damage m_damage;
    private GameObject player;
    void Awake()
    {
        m_damage = GetComponent<Damage>();
        player = GameObject.Find("XR Origin (XR Rig)");
        
    }
    // Start is called before the first frame update
    void Start()
    {
        m_damage.SetIgnore(player.GetComponent<Collider>());
        m_damage.SetIgnore(player.GetComponent<CharacterController>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
