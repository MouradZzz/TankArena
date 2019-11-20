using System.Collections.Generic;
using System.Linq;
using Entities;
using Managers;
using NodeUtilityAi;
using NodeUtilityAi.Nodes;
using UnityEngine;

namespace AI.SimpleEntryNodes {
    public class DistanceFromFarthestBonus : SimpleEntryNode {
        
        protected override int ValueProvider(AbstractAIComponent context) {
            TankAIComponent tankAiComponent = (TankAIComponent) context;
            List<GameObject> bonusEntities = GameManager.Instance.BonusEntities;
            float distanceFromFarthestBonus = Mathf.NegativeInfinity;
            if (bonusEntities.Count == 0) return (int) distanceFromFarthestBonus;
            distanceFromFarthestBonus = bonusEntities
                .Select(bonus => Vector3.Distance(bonus.transform.position, tankAiComponent.transform.position))
                .Concat(new[] {distanceFromFarthestBonus})
                .Max();
            return (int) distanceFromFarthestBonus;
        }
        
    }
}