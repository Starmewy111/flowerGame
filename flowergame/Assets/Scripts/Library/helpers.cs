using UnityEditor.XR;
using UnityEngine;

namespace Library
{
    public static class helpers
    {
        public static Transform ClosestToTarget(Transform target, Transform[] other)
        {
            Transform bestOther = null;
            float closest = Mathf.Infinity;

            foreach (Transform t in other)
            {
                float dist = Vector2.Distance(target.position, t.position);
                if (dist < closest)
                {
                    closest = dist;
                    bestOther = t;
                }
            }
            
            return bestOther;
        }

        public static bool FlipFlop(bool boolean)
        {
            boolean = !boolean;

            return boolean;
        }
        
    }
}