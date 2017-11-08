using UnityEngine;
using System.Collections.Generic;

public class FollowScript: MonoBehaviour {
 public Transform Character; // Target Object to follow
 public float speed = 0.1f; // Enemy speed
 private Vector3 directionOfCharacter;
 private bool challenged = true; // If the enemy is Challenged to follow by the player
 void Update() {
   if (challenged) {
    directionOfCharacter = Character.transform.position - transform.position;
    directionOfCharacter = directionOfCharacter.normalized; // Get Direction to Move Towards
    transform.Translate(directionOfCharacter * speed, Space.World);
   }
  }
}