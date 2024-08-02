using Godot;
using System;

public partial class GameScene : Node2D
{
	private TextureRect _hp1;
	private TextureRect _hp2;
	private TextureRect _hp3;
	private int _hp;
	public int Score;
	private Label ScoreLabel;
	private Label GameOverScore;
	
	[Export]
	public PackedScene EnemyScene = GD.Load<PackedScene>("res://scenes/EnemyScene.tscn");
	
	public override void _Ready()
	{
		Score = 0; 
		_initHealth();
		ScoreLabel = GetNode<Label>("HUD/ScoreLabel");
		GameOverScore = GetNode<Label>("GameOver/PanelContainer/MarginContainer/VBoxContainer/HBoxContainer/GameOverScore");
	}
	
	private void _initHealth()
	{
		_hp = 3;
		_hp1 = GetNode<TextureRect>("HUD/HP1");
		_hp2 = GetNode<TextureRect>("HUD/HP2");
		_hp3 = GetNode<TextureRect>("HUD/HP3");
		_updateHealthDisplay();
	}
	
	public void Contamination()
	{
		_hp--;
		if(_hp <= 0)
		{
			
			_gameOver();
		}
		_updateHealthDisplay();
	}
	
	private void _updateHealthDisplay()
	{
		_hp1.Visible = _hp >= 1;
		_hp2.Visible = _hp >= 2;
		_hp3.Visible = _hp >= 3;
	}
	
	private void _on_enemy_spawn_timer_timeout()
	{
		EnemyScene Enemy = EnemyScene.Instantiate<EnemyScene>();
	
		Enemy.Position = new Vector2((float)GD.RandRange(660, 1260), 0);
		Enemy.RotationDegrees = (float)GD.RandRange(0, 360);
		
		AddChild(Enemy);
	}
	
	private void _gameOver()
	{
		GetNode<Timer>("EnemySpawnTimer").Stop();
		GetNode<CanvasLayer>("GameOver").Show();
		
		GetNode<EnemyScene>("EnemyScene").QueueFree();
		
		GameOverScore.Text = Score.ToString();
		GetTree().Paused = true;
	}
	
	private void _on_retry_button_pressed()
	{
		GetTree().Paused = false;
		GetTree().ReloadCurrentScene();
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://scenes/MenuScene.tscn");
	}
	
	public void IncrementScore()
	{
		Score++;
		ScoreLabel.Text = Score.ToString();
	}
}
