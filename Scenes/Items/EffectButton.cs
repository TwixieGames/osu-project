using Godot;
using System;

public partial class EffectButton : Area2D
{
	[Export] Vector2 teleportSpot;
	public void BodyEnter(Player a)
	{
		GD.Print("This Works!");
		a.GlobalPosition = teleportSpot;
		QueueFree();
	}
}
