using Godot;
using System;

public partial class EnemyScene : RigidBody2D
{
	[Export]
	public float GravityScale = 1.0f;

	private Vector2 gravity;

	public override void _Ready()
	{
		gravity = new Vector2(0, 980) * GravityScale;
	}
}
