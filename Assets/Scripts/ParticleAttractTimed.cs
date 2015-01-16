using UnityEngine;
using System.Collections;

namespace Mod
{
	public class ParticleAttractTimed : MonoBehaviour
	{
		public float AttractRadius = 200;
		public float AttractTime = 1.5f;
		public Transform MagnetPoint;
		
		private void Start()
		{
		}
		
		private void Update()
		{
			ParticlePull();
		}
	
		private void ParticlePull()
		{
			float _sqrAttractRadius = AttractRadius * AttractRadius;
		
			ParticleSystem.Particle[] x = new ParticleSystem.Particle[gameObject.particleSystem.particleCount + 1]; 
			int y = particleSystem.GetParticles(x);
		

			for(int i = 0; i < y; i++)
			{
				Vector3 _distance = MagnetPoint.position - x[i].position;
				float _sqrDistance = _distance.sqrMagnitude;
			
				if(_sqrDistance <= _sqrAttractRadius)
				{

					float _lifeTime = x[i].lifetime;
					float _velocity = x[i].velocity.magnitude;
         

					if((_lifeTime < this.AttractTime) && (_lifeTime > 0.0f))
					{
						Vector3 _vec = MagnetPoint.position - x[i].position;
						_vec = _vec.normalized * 2000.0f;//(1500.0f - offset.magnitude);

						//x[i].velocity = Vector3.Slerp(x[i].velocity, _vec, Mathf.SmoothStep(0, 1.0f, (Time.deltaTime / 0.1F)));
						//x[i].velocity = Vector3.Slerp(x[i].velocity, _vec, (1.75f - _lifeTime)  );
						x[i].velocity = Vector3.Slerp(x[i].velocity, _vec, this.AttractTime - _lifeTime);

						if((x[i].position - MagnetPoint.position).magnitude <= 30.0f)
						{
							x[i].lifetime = 0;
						}
					}

					Quaternion _rot = Quaternion.LookRotation(this.transform.position - x[i].position);
					Vector3 _axis;
					float _angle;
					_rot.ToAngleAxis(out _angle, out _axis);
					x[i].axisOfRotation = _axis;
					x[i].rotation = _angle;
				}
			}
		
			gameObject.particleSystem.SetParticles(x, y);
			return;
		}

	}
}