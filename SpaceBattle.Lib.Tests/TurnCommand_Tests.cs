namespace SpaceBattle.Lib.Tests;

public class TurnCommand_Tests
{
    [Fact]
    public void TurnCommandAll()
    {
        var turnable = new Mock<IRotateble>();

        turnable.SetupGet(m => m.Angle).Returns(new Turn(45)).Verifiable();
        turnable.SetupGet(m => m.AngularSpeed).Returns(new Turn(45)).Verifiable();

        var turnCommand = new RotateCommand(turnable.Object);
        turnCommand.Execute();

        turnable.VerifySet(m => m.Angle = new Turn(90), Times.Once);
    }

    [Fact]
    public void NotAngle()
    {
        var turnable = new Mock<IRotateble>();

        turnable.SetupGet(m => m.Angle).Throws(new Exception()).Verifiable();
        turnable.SetupGet(m => m.AngularSpeed).Returns(new Turn(45)).Verifiable();

        var turnCommand = new RotateCommand(turnable.Object);
        Assert.Throws<Exception>(() => turnCommand.Execute());
    }

    [Fact]
    public void NotAngularSpeed()
    {
        var turnable = new Mock<IRotateble>();

        turnable.SetupGet(m => m.Angle).Returns(new Turn(45)).Verifiable();
        turnable.SetupGet(m => m.AngularSpeed).Throws(new Exception()).Verifiable();

        var turnCommand = new RotateCommand(turnable.Object);
        Assert.Throws<Exception>(() => turnCommand.Execute());
    }

    [Fact]
    public void NotChanges()
    {
        var turnable = new Mock<IRotateble>();

        turnable.SetupGet(m => m.Angle).Returns(new Turn(45)).Verifiable();
        turnable.SetupGet(m => m.AngularSpeed).Returns(new Turn(45)).Verifiable();
        turnable.SetupSet(m => m.Angle = It.IsAny<Turn>()).Throws(new Exception()).Verifiable();

        var turnCommand = new RotateCommand(turnable.Object);
        Assert.Throws<Exception>(() => turnCommand.Execute());
    }
}
