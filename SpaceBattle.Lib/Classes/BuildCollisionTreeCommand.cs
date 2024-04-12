using Hwdtech;

public class BuildCollisionTreeCommand : ICommand
{
    private readonly IArraysFromFileReader reader;

    public BuildCollisionTreeCommand(IArraysFromFileReader readerr)
    {
        reader = readerr;
    }

    public void Execute()
    {
        var arrays = reader.ReadArrays();

        arrays.ForEach(array =>
        {
            var node = IoC.Resolve<Dictionary<int, object>>("Game.Collisions.Tree");
            array.ToList().ForEach(num =>
            {
                node.TryAdd(num, new Dictionary<int, object>());
                node = (Dictionary<int, object>)node[num];
            });
        });
    }
}
