using Godot;
using System;

public partial class EnemyScene : RigidBody2D
{
	[Export]
	public float GravityScale = 0.5f;
	
	private Vector2 gravity;
	
	private GameScene _gameScript;
	
	public override void _Ready()
	{
		gravity = new Vector2(0, 980) * GravityScale;
		
		_gameScript = GetNode<GameScene>("..");
	}
	
	private void KillEnemy()
	{
		QueueFree();
		// TODO: add sound
	}

	private void _on_body_entered(Node body)
	{
		if(body.IsInGroup("Player"))
		{
			KillEnemy();
		}
		else
		{
			_gameScript.Contamination();
			KillEnemy();
		}
	}
}



