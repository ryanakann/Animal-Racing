using UnityEngine;

namespace Utils.Extensions
{
    public static class Extensions
    {
        public static float RandomGaussian(float mu, float sigma)
        {
            float u1 = 1f - Random.value;
            float u2 = 1f - Random.value;
            float z = Mathf.Sqrt(-2f * Mathf.Log(u1));
            float randNormal = mu + sigma * z;
            return randNormal;
        }
    }
}
