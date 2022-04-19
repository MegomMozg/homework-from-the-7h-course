using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Simple patrol behavior.
	/// This will set the destination on the agent so that it moves through the sequence of objects in the <see cref="targets"/> array.
	/// Upon reaching a target it will wait for <see cref="delay"/> seconds.
	///
	/// See: <see cref="Pathfinding.AIDestinationSetter"/>
	/// See: <see cref="Pathfinding.AIPath"/>
	/// See: <see cref="Pathfinding.RichAI"/>
	/// See: <see cref="Pathfinding.AILerp"/>
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_patrol.php")]
	public class Patrol : VersionedMonoBehaviour {
		/// <summary>Target points to move to in order</summary>
		public Transform[] targets;

		/// <summary>Time in seconds to wait at each target</summary>
		public float delay = 0;

		/// <summary>Current target index</summary>
		int index;

		bool Istarget;

		AIDestinationSetter PlayerTarget;

		AIPath Settings;

		IAstarAI agent;

		float switchTime = float.PositiveInfinity;

        private void Start()
        {
			Patrolmove();
		}
        protected override void Awake () {
			base.Awake();
			Settings = GetComponent<AIPath>();
			PlayerTarget = GetComponent<AIDestinationSetter>();
			agent = GetComponent<IAstarAI>();
		}

		/// <summary>Update is called once per frame</summary>
		void Update () 
		{
			if (Istarget == false)
            {

				Patrolmove();

			}
			else if (Istarget == true)
			{
				PlayerOntarget();
			}

		}
		/// <summary>
		/// Reacton in Player
		/// </summary>
		/// <param name="collision"></param>
		#region Reaction
		public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
				Istarget = true;
            }
        }
        
        public void OnTriggerExit2D(Collider2D collision)
        {
			if(collision.CompareTag("Player"))
				StartCoroutine(TimeOnPatrol());
		}
		#endregion  

		private void Patrolmove()
        {
            #region PlayerSettings
            Settings.repathRate = 1.6f;
			PlayerTarget.enabled = false;
            #endregion

            if (targets.Length == 0) return;

			bool search = false;

			// Note: using reachedEndOfPath and pathPending instead of reachedDestination here because
			// if the destination cannot be reached by the agent, we don't want it to get stuck, we just want it to get as close as possible and then move on.
			//if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) 
			//{
			//	switchTime = Time.time + delay;
			//}//фиг знает что это

			if (Time.time >= switchTime)
			{
				index = index + 1;
				search = true;
				switchTime = float.PositiveInfinity;
			}

			index = (index + 1) % targets.Length;
			agent.destination = targets[index].position;

			if (search) agent.SearchPath();
		}

		private void PlayerOntarget()
        {
			Settings.repathRate = 0;
			PlayerTarget.enabled = true;


		}

		private IEnumerator TimeOnPatrol()
        {
			
			yield return new WaitForSeconds(10f);
			Istarget = false;

		}
	}
}
