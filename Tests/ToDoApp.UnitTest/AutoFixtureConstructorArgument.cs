using System.Reflection;
using AutoFixture.Kernel;

namespace ToDoApp.UnitTests
{
    public class AutoFixtureConstructorArgument : ISpecimenBuilder
    {
        private readonly object _value;

        private readonly string _name;

        private readonly IList<Type> _allowedTypes;

        public AutoFixtureConstructorArgument(IList<Type> allowedTypes, string name, object value)
        {
            _allowedTypes = allowedTypes;
            _name = name;
            _value = value;
        }

        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is ParameterInfo pi))
            {
                return new NoSpecimen();
            }

            if (!_allowedTypes.Contains(pi.Member.DeclaringType)
                || pi.ParameterType != _value.GetType()
                || pi.Name != _name)
            {
                return new NoSpecimen();
            }

            return _value;
        }
    }
}