using Godot;
using System;

public partial class PlayerScene : CharacterBody2D
{
	public const float Speed = 600.0f;
	
	private GameScene _gameScript;
	private AudioStreamPlayer PlayerSound;
	
	public override void _Ready()
	{
		_gameScript = GetNode<GameScene>("..");
		PlayerSound = GetNode<AudioStreamPlayer>("PlayerSound");
	}
	
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
	
	private void _on_check_enemy_body_entered(Node2D body)
	{
		if(body.IsInGroup("Enemy"))
		{
			PlayerSound.Play();
			body.QueueFree();
			_gameScript.IncrementScore();
		}
	}
}
