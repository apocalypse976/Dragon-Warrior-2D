using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBallHolder : MonoBehaviour
{
   [SerializeField] private Transform Enemy;

    private void Update()
    {
        transform.localScale= Enemy.localScale;
    }
}
