// Project Cows -- GearShift Games
// Writen by D. Sinclair, 2016
//			 D. Divers, 2016
// ================
// CollisionHandler.cs

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

using Project_Cows.Source.Application.Entity;

namespace Project_Cows.Source.Application.Physics {
	public static class CollisionHandler {
		// Class for detecting and handling all Entity game collisions
		// ================

		// Variables


		// Methods

		// NOTE: Should be made private in future -Dean
		public static bool CheckForCollision(EntityCollider entityA_, EntityCollider entityB_) {
			// Checks to see if the two entities have collided
			// ================

			// Calculate the axis we will check collisions on
			List<Vector2> rectangleAxis = new List<Vector2>();
			rectangleAxis.Add(entityA_.GetCornerPosition(Corner.UPPER_RIGHT) - entityA_.GetCornerPosition(Corner.UPPER_LEFT));
			rectangleAxis.Add(entityA_.GetCornerPosition(Corner.UPPER_RIGHT) - entityA_.GetCornerPosition(Corner.LOWER_RIGHT));
			rectangleAxis.Add(entityB_.GetCornerPosition(Corner.UPPER_LEFT) - entityB_.GetCornerPosition(Corner.LOWER_LEFT));
			rectangleAxis.Add(entityB_.GetCornerPosition(Corner.UPPER_LEFT) - entityB_.GetCornerPosition(Corner.UPPER_RIGHT));

			// Loop through each axis, if one doesn't collide, there is no collision
			foreach(Vector2 axis in rectangleAxis) {
				if(!IsAxisCollision(entityB_, axis)) {
					return false;
				}
			}

			return true;
		}

		private static bool IsAxisCollision(EntityCollider entityB_, Vector2 axis_) {
			// Determines if a collision has occurred on an axis of one of the planes parallel to the entity
			// ================

			// Project the corners of the collider B on to the axis and get a scalar value of that project
			List<int> colliderAScalars = new List<int>();
			colliderAScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.UPPER_LEFT), axis_));
			colliderAScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.UPPER_RIGHT), axis_));
			colliderAScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.LOWER_LEFT), axis_));
			colliderAScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.LOWER_RIGHT), axis_));

			// Project the corners of the collider A onto the axis and get a scalar value of that project
			List<int> colliderBScalars = new List<int>();
			colliderBScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.UPPER_LEFT), axis_));
			colliderBScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.UPPER_RIGHT), axis_));
			colliderBScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.LOWER_LEFT), axis_));
			colliderBScalars.Add(GenerateScalar(entityB_.GetCornerPosition(Corner.LOWER_RIGHT), axis_));

			// Get the min and max scalar values for each collider
			int colliderAMin = colliderAScalars.Min();
			int colliderAMax = colliderAScalars.Max();
			int colliderBMin = colliderBScalars.Min();
			int colliderBMax = colliderBScalars.Max();

			// If there are any overlaps, there is a collision on this axis
			if(colliderBMin <= colliderAMax && colliderBMax >= colliderAMax) {
				return true;
			} else if(colliderAMin <= colliderBMax && colliderAMax >= colliderBMax) {
				return true;
			} else {
				return false;
			}
		}

		private static int GenerateScalar(Vector2 corner_, Vector2 axis_) {
			// Generates a scalar value that can be used to compare where corners of a rectangle have been projected onto an axis
			// ================

			// Project the corner onto the axis
			float divisionResult = ((corner_.X * axis_.X) + (corner_.Y * axis_.Y)) / ((axis_.X * axis_.X) + (axis_.Y * axis_.Y));
			Vector2 cornerProjection = new Vector2(divisionResult * axis_.X, divisionResult * axis_.Y);

			// Create scalar relative to the vector, for easier calculations
			float scalar = (axis_.X * cornerProjection.X) + (axis_.Y * cornerProjection.Y);
			return (int)scalar;
		}

		// Getters


		// Setters


	}
}
