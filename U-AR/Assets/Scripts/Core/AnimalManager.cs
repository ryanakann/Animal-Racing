using System.Collections.Generic;
using UnityEngine;
using Utils.Extensions;

namespace Core
{
    public class AnimalManager : MonoBehaviour
    {
        public GameObject animalPrefab;
        
        private List<Animal> _animals;
        private const float Variance = 0.2f;

        public Animal Breed(Animal parent1, Animal parent2)
        {
            Animal.Stats stats1 = parent1.GetStats();
            Animal.Stats stats2 = parent2.GetStats();
            
            

            float meanConstitution = (stats1.Constitution + stats2.Constitution) / 2f;
            Extensions.RandomGaussian(meanConstitution, Variance);
            
            float meanPoise = (stats1.Poise + stats2.Poise) / 2f;
            float meanSpeed = (stats1.Speed + stats2.Speed) / 2f;
            float meanStamina = (stats1.Stamina + stats2.Stamina) / 2f;
            float meanStyle = (stats1.Style + stats2.Style) / 2f;

            return null;
        }
    }
}
