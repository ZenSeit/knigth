using Godot;
using System;

public partial class Coin : Area2D
{

	public override void _Ready()
	{
		// Conectar la señal de entrada del cuerpo
		BodyEntered += OnBodyEntered;
	}

    private void OnBodyEntered(Node2D body)
	{
		QueueFree();
		// Aquí puedes agregar la lógica para recoger la moneda
	}
}
