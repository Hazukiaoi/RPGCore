﻿using RPGCore.Behaviour.Connections;
using System;
using UnityEngine;

namespace RPGCore.Behaviour.Math
{
	[NodeInformation ("Float/Lerp")]
	public class LerpNode : BehaviourNode
	{
		public FloatInput Min;
		public FloatInput Max;
		public FloatInput Value;

		public FloatOutput Output;

		protected override void OnSetup (IBehaviourContext context)
		{
			ConnectionEntry<float> valueInput = Value[context];
			ConnectionEntry<float> minInput = Min[context];
			ConnectionEntry<float> maxInput = Max[context];
			ConnectionEntry<float> output = Output[context];

			Action updateHandler = () =>
			{
				output.Value = Mathf.Lerp (minInput.Value, maxInput.Value, valueInput.Value);
			};

			valueInput.OnAfterChanged += updateHandler;
			minInput.OnAfterChanged += updateHandler;
			maxInput.OnAfterChanged += updateHandler;

			updateHandler ();
		}

		protected override void OnRemove (IBehaviourContext context)
		{
		}

#if UNITY_EDITOR
		public override Vector2 GetDiamentions ()
		{
			return new Vector2 (140, 70);
		}
#endif
	}
}

