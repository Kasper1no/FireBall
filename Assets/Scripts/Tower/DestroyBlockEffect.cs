using UnityEngine;

public class DestroyBlockEffect : MonoBehaviour
{
        [SerializeField] private ParticleSystemRenderer particleSystemRenderer;

        public ParticleSystemRenderer ParticleSystemRenderer
        {
                get {return particleSystemRenderer;}
        }
}
