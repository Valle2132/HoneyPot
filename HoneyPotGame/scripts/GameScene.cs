using Godot;
using System;

public partial class GameScene : Node2D
{
	private TextureRect _hp1;
	private TextureRect _hp2;
	private TextureRect _hp3;
	private int _hp;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_hp = 3;
		
		_hp1 = GetNode<TextureRect>("HUD/HP1");
		_hp2 = GetNode<TextureRect>("HUD/HP2");
		_hp3 = GetNode<TextureRect>("HUD/HP3");
		
		UpdateHealthDisplay();
	}
	
	public void Contamination()
	{
		_hp--;
		
		if(_hp <= 0)
		{
			GameOver();
		}
		
		UpdateHealthDisplay();
	}
	
	private void UpdateHealthDisplay()
	{
		_hp1.Visible = _hp >= 1;
		_hp2.Visible = _hp >= 2;
		_hp3.Visible = _hp >= 3;
	}
	
	private void GameOver()
	{
		// TODO
		GetTree().Quit();
	}
}
