using Godot;
using System;

public partial class EnemyScene : RigidBody2D
{
	[Export]
	public float GravityScale = 0.5f;
	
	private Vector2 gravity;
	
	private GameScene _gameScript;
	
	private AudioStreamPlayer PlayerSound;
	private AudioStreamPlayer EnemySound;
	
	public override void _Ready()
	{
		gravity = new Vector2(0, 980) * GravityScale;
		
		_gameScript = GetNode<GameScene>("..");
		
		PlayerSound = GetNode<AudioStreamPlayer>("PlayerSound");
		EnemySound = GetNode<AudioStreamPlayer>("EnemySound");
	}
	
	private async void KillEnemy()
	{
		QueueFree();
	}
}
