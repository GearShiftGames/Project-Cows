//Attempted by Dan the man

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;

using Project_Cows.Source.System;
using Project_Cows.Source.System.Graphics;
using Project_Cows.Source.System.Graphics.Sprites;

using System;

namespace Project_Cows.Source.Application.Entity {
	class Tire {
		private const float ACCELERATION_RATE = 10f;

		protected Body fs_body;
		
		float m_maxForwardSpeed;  // 100;
		float m_maxBackwardSpeed; // -20;
		float m_maxDriveForce;    // 150;

		public Sprite debugSprite = new Sprite(TextureHandler.m_debugCollider, new Vector2(0.0f, 0.0f), 0.0f, new Vector2(0.8f, 0.5f));

		public Tire(World world_, Texture2D texture_, Vector2 position_, float rotation_,  float restitution_ = 0.1f) 
		{
			// Tire constructor
			// ================
			
			fs_body = BodyFactory.CreateRectangle(world_, FarseerPhysics.ConvertUnits.ToSimUnits(0.8f), FarseerPhysics.ConvertUnits.ToSimUnits(0.5f), 1f, FarseerPhysics.ConvertUnits.ToSimUnits(position_));
			fs_body.BodyType = BodyType.Dynamic;    //bodyType_;
			fs_body.Mass = 2f;
			fs_body.Restitution = restitution_;
			fs_body.Rotation = Util.DegreesToRadians(rotation_);
			
			debugSprite.SetPosition(position_);
		}
	
		Vector2 getLateralVelocity()
		{
		    Vector2 currentRightNormal = fs_body.GetWorldVector(new Vector2(1,0));
		
		    return Vector2.Dot(currentRightNormal, fs_body.GetLinearVelocityFromWorldPoint(fs_body.GetWorldPoint(fs_body.Position))) * currentRightNormal;
		}

		Vector2 getForwardVelocity()
		{
			Vector2 currentForwardNormal = fs_body.GetWorldVector(new Vector2(0, 1));
			return Vector2.Dot(currentForwardNormal, fs_body.GetLinearVelocityFromWorldPoint(fs_body.GetWorldPoint(fs_body.Position))) * currentForwardNormal;
		}

		public void updateFriction()
		{
			int maxLateralImpulse = 3;

		    Vector2 impulse = fs_body.Mass * -getLateralVelocity();
			if(impulse.Length() > maxLateralImpulse)
		    fs_body.ApplyLinearImpulse(impulse); 
		
		    fs_body.ApplyAngularImpulse(0.1f * fs_body.Inertia * fs_body.AngularVelocity);

			//NO IDEA IF THIS EVEN WORKS
			Vector2 currentForwardNormal = getForwardVelocity();
			float currentForwardSpeed = currentForwardNormal.Length();
			
			//currentForwardSpeed.Normalize();

			float dragForceMagnitude = -2 * currentForwardSpeed;
			
			//THIS LINE BREAKS
			fs_body.ApplyForce(dragForceMagnitude * currentForwardNormal);
			fs_body.ApplyLinearImpulse(new Vector2(1,0));

			//fs_body.ApplyForce(new Vector2(0,-1) * ACCELERATION_RATE * 1.5f);

			debugSprite.SetPosition(FarseerPhysics.ConvertUnits.ToDisplayUnits(fs_body.Position));
			//TO HERE YA KEN
		}

		public void updateDrive(int steeringValue)
		{
			float desiredSpeed = 0;
			desiredSpeed = m_maxForwardSpeed;
				
			Vector2 currentForwardNormal = fs_body.GetWorldVector(new Vector2(0f,1f));
			float currentSpeed = Vector2.Dot(currentForwardNormal, getForwardVelocity());

			//apply necessary force
			float force = 0;
			if (desiredSpeed > currentSpeed)
				force = m_maxDriveForce;
			else if (desiredSpeed < currentSpeed)
				force = -m_maxDriveForce;
			else
				return;

			fs_body.ApplyForce(force * currentForwardNormal);

            debugSprite.SetPosition(FarseerPhysics.ConvertUnits.ToDisplayUnits(fs_body.Position));

		}

		//Applies torque based upon the direction of steering
		public void updateTurn(int steeringValue)
		{
			float desiredTorque = 0;

			if(steeringValue > 0)
			{
				desiredTorque = 15;
			}
			else if(steeringValue < 0)
			{
				desiredTorque = -15;
			}
			else desiredTorque = 0;

			fs_body.ApplyTorque(desiredTorque);
		}
	}
}
