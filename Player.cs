using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] float speed = 125;
	[Export] float jumpHeight = 40;
	[Export] float gravity = 250;
	[Export] int health = 20;
	Vector2 velocity;
	RayCast2D floorD;
	Label hp;

	//Allows for enemy and environment to damage the player
	public void TakeDamage(int damage)
	{
		health -= damage;
		GD.Print(health);
		if(health <= 0)
			GetTree().ChangeSceneToFile("res://Scenes/Menu/Respawn.tscn");
	}

	//Collects input for character movement
    private void GetInput()
	{
		velocity.X = Input.GetVector("left","right","jump","ui_down").X * speed;
		
		
		if(Input.IsActionPressed("jump") && floorD.IsColliding())
			velocity.Y -= jumpHeight;
	}

    //Runs when scene is started
    public override void _Ready()
    {
        AddToGroup("Player");
		floorD = GetNode<RayCast2D>("FloorDetect");
		hp = GetNode<Label>("Health");
    }

    //Gets called every frame
    public override void _Process(double delta)
	{
		hp.Text = "HP:" + health;
		velocity.Y += gravity *(float)delta;
		GetInput();
		Velocity = velocity;
		MoveAndSlide();
	}
}