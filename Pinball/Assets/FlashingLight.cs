using UnityEngine;
using System.Collections;

public class FlashingLight : MonoBehaviour {

   public Light flashingLight;

   void Start() {
      flashingLight.enabled = false;
   }

   void FixedUpdate() {
      float rand = Random.value;

      if( rand < 0.7f ) {
         flashingLight.enabled = true;
      }
      else {
         flashingLight.enabled = false;
      }
   }
}