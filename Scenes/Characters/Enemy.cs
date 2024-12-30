using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export] int damage = 5;
	[Export] float gravity = 500;
	[Export] float speed = 100;
	public bool follow = false;
	public Vector2 velocity;
	Vector2 pPosition;
	Label text;
	Timer tTime;
	Player p;

	//Calls whenever a PhysicsBody enters this Nodes Area2D Child
	public void BodyEnter(Player a)
	{
		text = GetNode<Label>("Message");
		tTime = GetNode<Timer>("Text Time");
		if(a.IsInGroup("Player"))
		{
			GD.Print("Get Out!");
			a.TakeDamage(damage);
			follow = true;
			pPosition = a.Position;
			text.Visible = true;
			tTime.Start(1);
			if(tTime.WaitTime <= 0.5)
				text.Visible = false;
		}
	}

	public void BodyExit(Player a)
	{
		if(a.IsInGroup("Player"))
			follow = false;
	}

	//Moves towards the player on the X-axis
	public void Movement()
	{
		velocity.X = 0;
		if(follow && pPosition.X <= Position.X)
		{
			velocity.X -= speed;
		}
		else if(follow && pPosition.X >= Position.X)
		{
			velocity.X += speed;
		}
	}

    public override void _Process(double delta)
    {
        Movement();
		velocity.Y += gravity * (float)delta;
		Velocity = velocity;
		MoveAndSlide();
    }

    
}
