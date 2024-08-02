using Godot;
using System;

public partial class MenuScene : Control
{
	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/GameScene.tscn");
	}
	
	private void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
}
