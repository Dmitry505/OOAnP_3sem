public class Turn_Tests
{
    [Fact]
    public void Turn_Equals()
    {
        var Angle = new Turn(45);
        var AngularSpeed = new Turn(45);
        Assert.True(Angle == AngularSpeed);
    }

    [Fact]
    public void TurnUnequals()
    {
        var Angle = new Turn(45, 360);
        var AngularSpeed = new Turn(90);
        Assert.True(Angle != AngularSpeed);
    }

    [Fact]
    public void Turn_HashCode()
    {
        var Angle = new Turn(45);
        var AngularSpeed = new Turn(45);
        Assert.False(Angle.GetHashCode() == AngularSpeed.GetHashCode());
    }

    [Fact]
    public void Turn_Equals_Null()
    {
        var Angle = new Turn(45);
        Assert.False(Angle.Equals(null));
    }

    [Fact]
    public void TurnEqualsFalsePosition()
    {
        var Angle = new Turn(45);
        var AngularSpeed = new Turn(45, 360);
        Assert.True(Angle.Equals(AngularSpeed));
    }
}
