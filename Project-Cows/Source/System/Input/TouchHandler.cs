// Project Cows -- GearShift Games
// Written by D. Sinclair, 2015
// ================
// TouchHandler.cs

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Project_Cows.Source.System.Input {
	class TouchHandler {
		// Deals with any touch input and makes the data accessible
		// ================

		// Variables
		private TouchCollection m_collection;
		private List<TouchLocation> m_touches;

		// Methods
		public TouchHandler() {
			// TouchHandler constructor
			// ================

			m_touches = new List<TouchLocation>();
			Update();
		}

		public void Update() {
			// Updates the touch handler with new data
			// ================

			m_collection = TouchPanel.GetState();
			m_touches.Clear();

			foreach(TouchLocation tl in m_collection) {
				m_touches.Add(tl);
			}
		}

		// Getters
		public List<TouchLocation> GetTouches() { return m_touches; }
	}
}
