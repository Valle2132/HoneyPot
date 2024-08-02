using Godot;
using System;

public partial class HoneyPotScene : Area2D
{
	private GameScene _gameScript;
	
	private AudioStreamPlayer EnemySound;
	
	public override void _Ready()
	{
		_gameScript = GetNode<GameScene>("..");
		EnemySound = GetNode<AudioStreamPlayer>("EnemySound");
	}
	
	private void _on_body_entered(Node2D body)
	{
		EnemySound.Play();
		_gameScript.Contamination();
		body.QueueFree();
	}
}
