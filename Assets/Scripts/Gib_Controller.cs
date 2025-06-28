using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gib_Controller : MonoBehaviour {

    
        [SerializeField] private float m_TimeOut = 15.0f;
        [SerializeField] private bool m_DetachChildren = false;
         [SerializeField]
        private bool isafk;


        private void Awake()
        {
            Invoke("Gib", m_TimeOut);
    
        }


        private void Gib()
        {
			Destroy(GetComponent<Rigidbody2D>());
			Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<BoxCollider2D>());
           
        }
    }


