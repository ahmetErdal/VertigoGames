using UnityEngine ;

namespace AeUI.PickerWheelUI
{
   [System.Serializable]
   public class WheelPiece {
      public UnityEngine.Sprite Icon ;
      public string Label ;
      public bool didİtComeBefore=false;
      public int counter=0;

      [Tooltip ("Reward amount")] public int Amount ;

      [Tooltip ("Probability in %")] 
      [Range (0f, 100f)] 
      public float Chance = 100f ;

      [HideInInspector] public int Index ;
      [HideInInspector] public double _weight = 0f ;
   }
}
