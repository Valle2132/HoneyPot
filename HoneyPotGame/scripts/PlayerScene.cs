using Godot;
using System;

public partial class PlayerScene : CharacterBody2D
{
	public const float Speed = 300.0f;
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}

	/*
		if(body.IsInGroup("Player"))
		{
			PlayerSound.Play();
			KillEnemy();
		}
		else
		{
			EnemySound.Play();
			_gameScript.Contamination();
			KillEnemy();
		}
	*/
}
