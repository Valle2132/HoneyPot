using Godot;
using System;

public partial class EnemyScene : RigidBody2D
{
	[Export]
	public float GravityScale = 0.5f;
	
	private Vector2 gravity;

	public override void _Ready()
	{
		gravity = new Vector2(0, 980) * GravityScale;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		if (MoveAndCollide(gravity * (float)delta) != null)
		{
			KillEnemy();
		}
	}
	
	private void KillEnemy()
	{
		QueueFree();
		
		// TODO: add sound
	}
}
