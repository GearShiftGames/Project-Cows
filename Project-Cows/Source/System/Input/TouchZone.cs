// Project: Cow Racing -- GearShift Games
// Written by D. Sinclair, 2015
// ================
// TouchZone.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Project_Cows.Source.System.Input {
	class TouchZone {
		// Sets a rectangular zone which can check if a coordinate in within it
		// ================

		// Variables
		private Vector2 m_min;
		private Vector2 m_max;


		// Methods
		public TouchZone(Vector2 min_, Vector2 max_) {
			// TouchZone constructor
			// ================

			SetMin(min_);
			SetMax(max_);
		}

		public TouchZone(TouchZone zone_) {
			// TouchZone constructor
			// ================

			SetMin(zone_.GetMin());
			SetMax(zone_.GetMax());
		}

		public bool IsInsideZone(Vector2 position_) {
			// Checks whether the position is within the touch zone
			// ================

			if(position_.X < m_min.X)
				return false;
			if(position_.X > m_max.X)
				return false;
			if(position_.Y < m_min.Y)
				return false;
			if(position_.Y > m_max.Y)
				return false;

			return true;
		}


		// Getters
		public Vector2 GetMin() { return m_min; }

		public Vector2 GetMax() { return m_max; }


		// Setters
		public void SetMin(Vector2 min_) { m_min = min_; }

		public void SetMax(Vector2 max_) { m_max = max_; }
	}
}
