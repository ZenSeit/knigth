using Godot;
using System;

public partial class Killzone : Area2D
{
    Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        BodyEntered += OnBodyEntered;
        timer.Timeout += OnTimerTimeout; // Conectar la señal Timeout
    }

    private void OnBodyEntered(Node2D body)
    {
        timer.Start();
    }

    private void OnTimerTimeout()
    {
        GetTree().ReloadCurrentScene();
    }
}