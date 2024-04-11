﻿public class RotateCommand : ICommand
{
    private readonly IRotateble rotatable;

    public RotateCommand(IRotateble rotatable)
    {
        this.rotatable = rotatable;
    }

    public void Execute()
    {
        rotatable.Angle += rotatable.AngularSpeed;
    }
}
