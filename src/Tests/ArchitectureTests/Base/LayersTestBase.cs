using System.Reflection;

namespace ArchitectureTests.Base;

public class LayersTestBase
{
    private readonly Assembly _assembly;

    public LayersTestBase(Assembly assembly)
    {
        _assembly = assembly;
    }


    [Fact]
    public void Domain_ShouldNot_HaveDependencyOnApplication()
    {
        var result = Types.InAssembly(_assembly)
            .Should()
            .NotHaveDependencyOn("Application")
            .GetResult();


    }

    [Fact]
    public void Domain_ShouldNot_HaveDependencyOnInfrastructure()
    {

    }

    [Fact]
    public void Application_ShouldNot_HaveDependencyOnInfrastructure()
    {

    }

    [Fact]
    public void Application_Should_HaveDependencyOnDomain()
    {

    }

    [Fact]
    public void Infrastructure_Should_HaveDependencyOnDomain()
    {

    }

    [Fact]
    public void Infrastructure_Should_HaveDependencyOnApplication()
    {

    }
}